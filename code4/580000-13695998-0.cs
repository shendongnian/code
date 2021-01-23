    using System;
    using System.Data;
    using System.Text;
    namespace SAPS
    {
    public class clsPhoneNumber
    {
		#region Fields (4) 
        private int _contacts_FK;
        private string _errMsg;
        private string _phoneNumber;
        private int _phoneNumbers_PK;
        private int _phoneTypes_FK;
        private string _phoneType;
		#endregion Fields 
		#region Constructors (1) 
        public  clsPhoneNumber()
        {
            _errMsg = "";
            _phoneNumbers_PK = 0;
            _phoneTypes_FK = 0;
            _phoneType = "";
            _phoneNumber = "";
            _contacts_FK = 0;
        }
		#endregion Constructors 
		#region Properties (4) 
        public int ContactsFk
        {
            get { return _contacts_FK; }
            set { _contacts_FK = value; }
        }
        public string ErrMsg
        {
            get { return _errMsg; }
            set { _errMsg = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = SAPSCommon.Instance.StripNonNumerics(value); }
        }
        public int PhoneNumbersPK
        {
            get { return _phoneNumbers_PK; }
            set { _phoneNumbers_PK = value; }
        }
        public int PhoneTypesFK
        {
            get { return _phoneTypes_FK; }
            set { _phoneTypes_FK = value; }
        }
        public string PhoneType
        {
            get { return _phoneType; }
        }
        #endregion Properties 
		#region Methods (2) 
		// Public Methods (1) 
        /// <summary>
        /// Get the Notes for the specified key
        /// </summary>
        /// <param name="TableID">The Table Primary Key</param>
        /// <returns>An Object containing data for the specified Primary Key</returns>
        public clsPhoneNumber GetData(int TableID)
        {
            AssignProperties(SAPSCommon.Instance.ReadTable("PhoneNumbers", "PN_PhoneNumbers_PK", TableID));
            return this;
        }
		// Private Methods (1) 
        /// <summary>
        /// Assigns the table's data to the properties of the Data Object.
        /// This method must be hand coded for each table.
        /// </summary>
        /// <param name="ds">A Dataset containing the data record read from the Table</param>
        private void AssignProperties(DataSet ds)
        {
            //Assign properties with database data
            try
            {
                //Primary Key for Table
                _phoneNumbers_PK = ds.Tables[0].Rows[0].Field<int>("PN_PhoneNumbers_PK");
                //The rest of the data fields
                _contacts_FK = ds.Tables[0].Rows[0].Field<int>("PN_Contacts_FK");
                _phoneNumber = FormatPhoneNumber(ds.Tables[0].Rows[0].Field<string>("PN_PhoneNum"));
                _phoneTypes_FK = ds.Tables[0].Rows[0].Field<int>("PN_PhoneTypes_FK");
                //Follow links of Foreign Keys
                DataTable dt = new DataTable();
                string sqlSelect =
                    string.Format(
                        "SELECT PT_Description FROM Pensions.dbo.PhoneTypes WHERE PT_PhoneTypes_PK = '{0}'",
                        _phoneTypes_FK);             
                dt = SQLCommon.Instance.SQLSelect(sqlSelect);
                _phoneType = dt.Rows[0].Field<string>("PT_Description");
            }
            catch (Exception e)
            {
                _errMsg = e.Message;
                SAPSCommon.Instance.ShowErrorMsg(e.Message);
            }
        }
        /// <summary>
        /// Format an Australian Phone number
        /// </summary>
        /// <param name="Num">Phone Number to format in string format</param>
        /// <returns>Formatted Phone Number</returns>
        private string FormatPhoneNumber(string Num)
        {
            if (Num.Substring(0, 2) == "04") //Mobile Number
            {
                return string.Format("{0:0### ### ###}", Convert.ToInt64(Num));
            }
            return string.Format("{0:(0#) #### ####}", Convert.ToInt64(Num));
        }
        #endregion Methods 
        public string  Update()
        {
            StringBuilder sb = new StringBuilder("UPDATE [");
            sb.Append(Properties.Settings.Default.SQLDatabaseName);
            sb.Append("].[dbo].[PhoneNumbers] SET PN_Contacts_FK='");
            sb.Append(_contacts_FK);
            sb.Append("', PN_PhoneTypes_FK='");
            sb.Append(_phoneTypes_FK);
            sb.Append("', PN_PhoneNum='");
            sb.Append(_phoneNumber);
            sb.Append("' WHERE PN_PhoneNumbers_PK='");
            sb.Append(_phoneNumbers_PK);
            sb.Append("'");
            _errMsg = SQLCommon.Instance.SQLUpdate(sb.ToString());
            return _errMsg;
        }
    }
