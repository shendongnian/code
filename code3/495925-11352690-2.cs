    public class EmailMailingList
    {
        
        private string _emailList;
    
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
