    class ReligionCaste
    {
        //public int religion_ID, caste_ID;
        public String religion, sect, caste, subCaste;
        public int pID;
        private DatabaseHandler.DBCntrlr dbObj;
        
        public ReligionCaste()
        {
            dbObj = new DatabaseHandler.DBCntrlr();
            pID = dbObj.LastEnteredRecord();
        }  
     }
