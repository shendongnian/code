    class ReligionCaste
    {
        public ReligionCaste()
        {
            pID = dbObj.LastEnteredRecord();
        }
        //public int religion_ID, caste_ID;
        public String religion, sect, caste, subCaste;
        public int pID;
        DatabaseHandler.DBCntrlr dbObj = new DatabaseHandler.DBCntrlr();
     }
