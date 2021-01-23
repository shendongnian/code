    public class EmailMailingList
    {
        #region members
        private string _emailList;
        #endregion
        #region properties
        /// <summary>
        /// gets or sets Customer Email for Mailing List
        /// </summary>
        public string EmailList
        {
            get { return _emailList; }
            set { _emailList = value; }
        }
        #endregion
       public void Save()
       {
          //Insert (this.EmailList); to database
       }
    }
    //Use:
    EmailMailingList ml = new EmailMailingList();
    ml.EmailList = "blah";
    ml.Save();
