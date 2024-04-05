/* Title:           Part Number Class
 * Date:            4-27-16
 * Author:          Terry Holmes
 *
 * Description:     This is the part class for all applications */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;
using DataValidationDLL;
using KeyWordDLL;

namespace PartNumberDLL
{
    public class PartNumberClass
    {
        //setting up the class
        EventLogClass TheEventLogClass = new EventLogClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();

        //Setting up the data
        PartNumbersDataSet aPartNumbersDataSet;
        PartNumbersDataSet ThePartNumberDataSet;
        PartNumbersDataSet TheFilteredPartNumberDataSet = new PartNumbersDataSet();
        PartNumbersDataSetTableAdapters.partnumbersTableAdapter aPartNumbersTableAdapter;

        PartNumberIDDataSet aPartNumberIDDataSet;
        PartNumberIDDataSetTableAdapters.PartNumberIDTableAdapter aPartNumberIDTableAdapter;

        CostingDataSet aCostingDataSet;
        CostingDataSetTableAdapters.costingTableAdapter aCostingTableAdapter;

        PricingDataSet aPriceingDataSet;
        PricingDataSetTableAdapters.pricingTableAdapter aPricingTableAdapter;

        MasterPartListDataSet aMasterPartListDataSet;
        MasterPartListDataSetTableAdapters.masterpartlistTableAdapter aMasterPartListTableAdapter;

        public bool RemovePartFromPartList(int intPartID)
        {
            bool blnFatalError = false;

            try
            {
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.RemovePartFromPartList(intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class \\ Remove Part From Part List " + Ex.Message);
            }

            return blnFatalError;
        }
        public MasterPartListDataSet FindPartIDFromMasterPartList(int intPartID)
        {
            try
            {
                aMasterPartListDataSet = new MasterPartListDataSet();
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.FindPartByPartID(aMasterPartListDataSet.masterpartlist, intPartID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Master Part List Data Set " + Ex.Message);
            }

            return aMasterPartListDataSet;
        }
        public MasterPartListDataSet FindJDEPartFromMasterPartList(string strJDEPartNumber)
        {
            try
            {
                aMasterPartListDataSet = new MasterPartListDataSet();
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.FindPartByJDEPartNumber(aMasterPartListDataSet.masterpartlist, strJDEPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Master Part List Data Set " + Ex.Message);
            }

            return aMasterPartListDataSet;
        }
        public MasterPartListDataSet FindPartFromMasterPartList(string strPartNumber)
        {
            try
            {
                aMasterPartListDataSet = new MasterPartListDataSet();
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.FindPartByPartNumber(aMasterPartListDataSet.masterpartlist, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Master Part List Data Set " + Ex.Message);
            }

            return aMasterPartListDataSet;
        }
        public MasterPartListDataSet GetMasterPartListDataSet()
        {
            try
            {
                aMasterPartListDataSet = new MasterPartListDataSet();
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.Fill(aMasterPartListDataSet.masterpartlist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Master Part List Data Set " + Ex.Message);
            }

            return aMasterPartListDataSet;
        }
        public void UpdateMasterPartListDB(MasterPartListDataSet aMasterPartListDataSet)
        {
            try
            {
                aMasterPartListTableAdapter = new MasterPartListDataSetTableAdapters.masterpartlistTableAdapter();
                aMasterPartListTableAdapter.Update(aMasterPartListDataSet.masterpartlist);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Update  Master Part List DB " + Ex.Message);
            }
        }

        public PartNumbersDataSet FindPartByJDEPartNumber(string strJDEPartNumber)
        {
            try
            {
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.FindPartByJDEPartNumber(aPartNumbersDataSet.partnumbers, strJDEPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find Part By JDE Part Number " + Ex.Message);
            }

            return aPartNumbersDataSet;
        }
        public PricingDataSet GetPricingByDescription(string strDescription)
        {
            try
            {
                aPriceingDataSet = new PricingDataSet();
                aPricingTableAdapter = new PricingDataSetTableAdapters.pricingTableAdapter();
                aPricingTableAdapter.GetPricingByDescription(aPriceingDataSet.pricing, strDescription);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Pricing Info " + Ex.Message);
            }

            return aPriceingDataSet;
        }
        public PricingDataSet GetPricingByPartNumber(string strPartNumber)
        {
            try
            {
                aPriceingDataSet = new PricingDataSet();
                aPricingTableAdapter = new PricingDataSetTableAdapters.pricingTableAdapter();
                aPricingTableAdapter.GetPricingByPartNumber(aPriceingDataSet.pricing, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Pricing Info " + Ex.Message);
            }

            return aPriceingDataSet;
        }
        public PricingDataSet GetPricingInfo()
        {
            try
            {
                aPriceingDataSet = new PricingDataSet();
                aPricingTableAdapter = new PricingDataSetTableAdapters.pricingTableAdapter();
                aPricingTableAdapter.Fill(aPriceingDataSet.pricing);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Pricing Info " + Ex.Message);
            }

            return aPriceingDataSet;
        }
        public void UpdatePricingDB(PricingDataSet aPricingDataSet)
        {
            try
            {
                aPricingTableAdapter = new PricingDataSetTableAdapters.pricingTableAdapter();
                aPricingTableAdapter.Update(aPriceingDataSet.pricing);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Pricing Info " + Ex.Message);
            }
        }
        public CostingDataSet GetCostingByDescription(string strDescription)
        {
            try
            {
                aCostingDataSet = new CostingDataSet();
                aCostingTableAdapter = new CostingDataSetTableAdapters.costingTableAdapter();
                aCostingTableAdapter.GetCostByDescription(aCostingDataSet.costing, strDescription);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Costing Info " + Ex.Message);
            }

            return aCostingDataSet;
        }

        public CostingDataSet GetCostingByPartNumber(string strPartNumber)
        {
            try
            {
                aCostingDataSet = new CostingDataSet();
                aCostingTableAdapter = new CostingDataSetTableAdapters.costingTableAdapter();
                aCostingTableAdapter.GetCostByPartNumber(aCostingDataSet.costing, strPartNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Costing By Part Numberf " + Ex.Message);
            }

            return aCostingDataSet;
        }
        public CostingDataSet GetCostingInfo()
        {
            try
            {
                aCostingDataSet = new CostingDataSet();
                aCostingTableAdapter = new CostingDataSetTableAdapters.costingTableAdapter();
                aCostingTableAdapter.Fill(aCostingDataSet.costing);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Costing Info " + Ex.Message);
            }

            return aCostingDataSet;
        }
        public void UpdateCostingDB(CostingDataSet aCostingDataSet)
        {
            try
            {
                aCostingTableAdapter = new CostingDataSetTableAdapters.costingTableAdapter();
                aCostingTableAdapter.Update(aCostingDataSet.costing);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Costing Info " + Ex.Message);
            }
        }
        public PartNumbersDataSet GetPartByPartNumber(string strPartNumber)
        {
            try
            {
                //filling the data set
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.GetPartByPartNumber(aPartNumbersDataSet.partnumbers, strPartNumber);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Part Number By Part ID " + Ex.Message);
            }

            //returning value
            return aPartNumbersDataSet;
        }
        public PartNumbersDataSet GetPartNumberByDescriptionKey(string strDescription)
        {
            try
            {
                //filling the data set
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.FindPartsByKeyWord(aPartNumbersDataSet.partnumbers, strDescription);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Part Number By Part ID " + Ex.Message);
            }

            //returning value
            return aPartNumbersDataSet;
        }
        public PartNumbersDataSet GetPartNumberByPartID(int intPartID)
        {
            try
            {
                //filling the data set
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.FillBy(aPartNumbersDataSet.partnumbers, intPartID);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Part Number By Part ID " + Ex.Message);
            }

            //returning value
            return aPartNumbersDataSet;
        }
        public PartNumbersDataSet GetFilteredPartNumberDataSetByID(int intPartID)
        {
            int intCounter;
            int intNumberOfRecords;
            
            try
            {
                //filling the data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting record count
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(ThePartNumberDataSet.partnumbers[intCounter].PartID == intPartID)
                    {
                        //creating the row
                        PartNumbersDataSet.partnumbersRow NewTableRow = TheFilteredPartNumberDataSet.partnumbers.NewpartnumbersRow();

                        //loading the fields
                        NewTableRow.Active = ThePartNumberDataSet.partnumbers[intCounter].Active;
                        NewTableRow.Description = ThePartNumberDataSet.partnumbers[intCounter].Description;
                        NewTableRow.JDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                        NewTableRow.PartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                        NewTableRow.PartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;
                        NewTableRow.PartType = ThePartNumberDataSet.partnumbers[intCounter].PartType;
                        NewTableRow.Price = ThePartNumberDataSet.partnumbers[intCounter].Price;
                        NewTableRow.TimeWarnerPart = ThePartNumberDataSet.partnumbers[intCounter].TimeWarnerPart;

                        //adding the row
                        TheFilteredPartNumberDataSet.partnumbers.Rows.Add(NewTableRow);
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Filtered Part Number Data Set " + Ex.Message);
            }

            //returning value
            return TheFilteredPartNumberDataSet;
        }
        public PartNumbersDataSet GetFilteredPartNumberDataSet(string strPartNumber)
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;
            bool blnKeyWordNotFound;
            bool blnNotTWCPartNumber;
            string strPartNumberForCheck;
            bool blnCreateEntry = false;

            try
            {
                //filling the data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting record count
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //setting bool variable
                    blnCreateEntry = false;

                    //getting the part number
                    strPartNumberForCheck = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;

                    blnNotTWCPartNumber = CheckTimeWarnerPart(strPartNumber);

                    if(blnNotTWCPartNumber == false)
                    {
                        if(strPartNumberForCheck == strPartNumber)
                        {
                            blnCreateEntry = true;
                        }
                    }
                    else
                    {
                        if(strPartNumber == ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber)
                        {
                            blnCreateEntry = true;
                        }
                        else
                        {
                            //keyword search
                            blnKeyWordNotFound = TheKeyWordClass.FindKeyWord(strPartNumber, ThePartNumberDataSet.partnumbers[intCounter].Description);

                            //checking boolean
                            if(blnKeyWordNotFound == false)
                            {
                                blnCreateEntry = true;
                            }
                        }
                    }

                    if(blnCreateEntry == true)
                    {
                        //creating the row
                        PartNumbersDataSet.partnumbersRow NewTableRow = TheFilteredPartNumberDataSet.partnumbers.NewpartnumbersRow();

                        //loading the fields
                        NewTableRow.Active = ThePartNumberDataSet.partnumbers[intCounter].Active;
                        NewTableRow.Description = ThePartNumberDataSet.partnumbers[intCounter].Description;
                        NewTableRow.JDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                        NewTableRow.PartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                        NewTableRow.PartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber;
                        NewTableRow.PartType = ThePartNumberDataSet.partnumbers[intCounter].PartType;
                        NewTableRow.Price = ThePartNumberDataSet.partnumbers[intCounter].Price;
                        NewTableRow.TimeWarnerPart = ThePartNumberDataSet.partnumbers[intCounter].TimeWarnerPart;

                        //adding the row
                        TheFilteredPartNumberDataSet.partnumbers.Rows.Add(NewTableRow);
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Filtered Part Number Data Set " + Ex.Message);
            }

            return TheFilteredPartNumberDataSet;
        }
        public string FindJDEPartNumberFromPartNumber(string strPartNumber)
        {
            //setting local variables
            string strJDEPartNumber = "";
            int intCounter;
            int intNumberOfRecords;

            try
            {
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting ready for the loop
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //Loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(strPartNumber == ThePartNumberDataSet.partnumbers[intCounter].PartNumber)
                    {
                        strJDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber;
                    }
                }
            }
            catch(Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find JDE Part Number From Part Number " + Ex.Message);
            }

            //returning value
            return strJDEPartNumber;
        }
        public int FindPartIDFromJDEPartNumber(string strJDEPartNumber)
        {
            //creating part id
            int intPartID = 0;
            int intCounter;
            int intNumberOfRecords;

            try
            {
                //loading the data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting ready for the loop
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if(strJDEPartNumber == ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber.ToUpper())
                    {
                        intPartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                    }
                }
            }
            catch(Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find Part ID From JDE Part Number " + Ex.Message);
            }

            //returning value
            return intPartID;
        }
        public bool CreateNewPart(string strDescription, string strJDEPartNumber, string strPartNumber,string strPartType, double douPrice, string strTimeWarnerPart, string strType)
        {
            //setting local variables
            bool blnFatalError = false;

            try
            {
                //loading the part data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //creating new row
                PartNumbersDataSet.partnumbersRow NewTableRow = ThePartNumberDataSet.partnumbers.NewpartnumbersRow();

                //loading the fields
                NewTableRow.Active = "YES";
                NewTableRow.Description = strDescription;
                NewTableRow.JDEPartNumber = strJDEPartNumber;
                NewTableRow.PartID = CreatePartID();
                NewTableRow.PartNumber = strPartNumber;
                NewTableRow.PartType = strPartType;
                NewTableRow.Price = douPrice;
                NewTableRow.TimeWarnerPart = strTimeWarnerPart;
                NewTableRow.Type = strType;

                //updating the table
                ThePartNumberDataSet.partnumbers.Rows.Add(NewTableRow);
                UpdatePartNumbersDB(ThePartNumberDataSet);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Create New Part " + Ex.Message);

                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }
        public bool FixDBNullPartNumber()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            string strPartNumber;
            string strDescription;
            string strPartType;
            string strType;
            bool blnSomethingChanged;
            string strJDEPartNumber;

            try
            {
                //loading the data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting ready for the loop
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //for loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    blnSomethingChanged = false;

                    strPartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber.ToUpper();
                    strDescription = ThePartNumberDataSet.partnumbers[intCounter].Description.ToUpper();
                    strPartType = ThePartNumberDataSet.partnumbers[intCounter].PartType.ToUpper();
                    strType = ThePartNumberDataSet.partnumbers[intCounter].Type.ToUpper();
                    strJDEPartNumber = ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber.ToUpper();

                    if(strPartNumber == "")
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].PartNumber = "'";
                        blnSomethingChanged = true;                        
                    }
                    if(strDescription == "")
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Description = "NO DESCRIPTION ENTERED";
                        blnSomethingChanged = true;
                    }
                    if(strPartType == "")
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].PartType = "NO PART TYPE ENTERED";
                        blnSomethingChanged = true;
                    }
                    if(strType == "")
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].Type = "NO TYPE ENTERED";
                        blnSomethingChanged = true;
                    }
                    if(strJDEPartNumber == "")
                    {
                        ThePartNumberDataSet.partnumbers[intCounter].JDEPartNumber = "NO JDE PART NUMBER";
                        blnSomethingChanged = true;
                    }

                    if(blnSomethingChanged == true)
                    {
                        UpdatePartNumbersDB(ThePartNumberDataSet);
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Fix DBNull Issue " + Ex.Message);

                //setting variable so the routine will fail
                blnFatalError = true;
            }


            //returning value
            return blnFatalError;
        }
        public string FindPartNumber(int intPartID)
        {
            //setting local variables
            string strPartNumber = "";
            int intCounter;
            int intNumberOfRecords;
            int intPartIDFromTable;

            try
            {
                //filling data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting the number of records
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //doing the loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    intPartIDFromTable = ThePartNumberDataSet.partnumbers[intCounter].PartID;

                    if(intPartID == intPartIDFromTable)
                    {
                        strPartNumber = ThePartNumberDataSet.partnumbers[intCounter].PartNumber.ToUpper();
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find Part Number " + Ex.Message);
            }

            //returning value
            return strPartNumber;
        }
        public int FindPartID(string strPartNumber)
        {
            //setting local variables
            int intPartID = 0;
            int intCounter;
            int intNumberOfRecords;
            string strPartNumberFromTable;

            try
            {
                //filling data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting the number of records
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //doing the loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //getting the part number
                    strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intCounter].PartNumber.ToUpper();

                    //if statements
                    if (strPartNumberFromTable == strPartNumber)
                    {
                        intPartID = ThePartNumberDataSet.partnumbers[intCounter].PartID;
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find Part ID " + Ex.Message);
            }


            //returning value to calling method
            return intPartID;
        }
        public string FindPartDescription(string strPartNumber)
        {
            //setting local variables
            string strPartDescription = "";
            int intCounter;
            int intNumberOfRecords;
            string strPartNumberFromTable;

            try
            {
                //filling data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting the number of records
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //doing the loop
                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //getting the part number
                    strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intCounter].PartNumber.ToUpper();

                    //if statements
                    if (strPartNumberFromTable == strPartNumber)
                    {
                        strPartDescription = ThePartNumberDataSet.partnumbers[intCounter].Description.ToUpper();
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Find Part Description " + Ex.Message);
            }


            //returning value to calling method
            return strPartDescription;
        }
        public bool CheckTimeWarnerPart(string strPartNumber)
        {
            //setting local variables
            bool blnNotTWCPartNumber = false;
            int intPartNumberForValidation;
            int intCharacterCounter;

            //getting the string length
            intCharacterCounter = strPartNumber.Length;

            //checking length
            if(intCharacterCounter > 7)
            {
                blnNotTWCPartNumber = true;
            }
            else
            {
                //checking integer
                blnNotTWCPartNumber = TheDataValidationClass.VerifyIntegerData(strPartNumber);
            }

            //checking value
            if(blnNotTWCPartNumber == false)
            {
                //setting an integer
                intPartNumberForValidation = Convert.ToInt32(strPartNumber);

                //checking the value
                if(intPartNumberForValidation < 1000000 || intPartNumberForValidation > 9999999)
                {
                    blnNotTWCPartNumber = true;
                }
            }

            //returning value
            return blnNotTWCPartNumber;
        }
        public bool VerifyPartNumber(string strPartNumber)
        {
            //setting local variables
            bool blnItemFound = false;
            int intCounter;
            int intNumberOfRecords;
            string strPartNumberFromTable;

            try
            {
                //filling data set
                ThePartNumberDataSet = GetPartNumbersInfo();

                //getting the number of records
                intNumberOfRecords = ThePartNumberDataSet.partnumbers.Rows.Count - 1;

                //doing the loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //getting the part number
                    strPartNumberFromTable = ThePartNumberDataSet.partnumbers[intCounter].PartNumber.ToUpper();

                    //if statements
                    if(strPartNumberFromTable == strPartNumber)
                    {
                        blnItemFound = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Verify Part Number " + Ex.Message);
            }

            return blnItemFound;
        }
       
        public PartNumbersDataSet GetPartNumbersInfo()
        {
            try
            {
                //filling the data set
                aPartNumbersDataSet = new PartNumbersDataSet();
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.Fill(aPartNumbersDataSet.partnumbers);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Get Part Numbers Info " + Ex.Message);
            }

            //returning value
            return aPartNumbersDataSet;
        }
        public void UpdatePartNumbersDB(PartNumbersDataSet aPartNumbersDataSet)
        {
            try
            {
                //filling the data set
                aPartNumbersTableAdapter = new PartNumbersDataSetTableAdapters.partnumbersTableAdapter();
                aPartNumbersTableAdapter.Update(aPartNumbersDataSet.partnumbers);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Update Part Numbers DB " + Ex.Message);
            }
        }
        //creating the part id
        public int CreatePartID()
        {
            //setting up the id
            int intPartID = 0;

            try
            {
                //filling the data set
                aPartNumberIDDataSet = new PartNumberIDDataSet();
                aPartNumberIDTableAdapter = new PartNumberIDDataSetTableAdapters.PartNumberIDTableAdapter();
                aPartNumberIDTableAdapter.Fill(aPartNumberIDDataSet.PartNumberID);

                intPartID = aPartNumberIDDataSet.PartNumberID[0].PartID;
                intPartID++;

                aPartNumberIDDataSet.PartNumberID[0].PartID = intPartID;
                aPartNumberIDTableAdapter.Update(aPartNumberIDDataSet.PartNumberID);
            }
            catch (Exception Ex)
            {
                //event log entry
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Part Number Class Create Part ID " + Ex.Message);
            }

            //returning value
            return intPartID;
        }
    }
}
