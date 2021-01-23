    class ReligionCaste
    {
        //public int religion_ID, caste_ID;
        public String religion, sect, caste, subCaste;
        public int pID;
        
        public ReligionCaste()
        {
            DatabaseHandler.DBCntrlr dbObj = new DatabaseHandler.DBCntrlr();
            pID = dbObj.LastEnteredRecord();
        }  
     }
