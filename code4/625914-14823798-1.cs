    sealed class MyImporter
    {
        private readonly DbInterface db;
        public MyImporter(DbInterface db)
        {
            this.db = db;
        }
        public void ImportAllData()
        {
            var records = PullData();
            PushData(records);
        }
        private DbRecord[] PullData()
        {
            return db.GetFromTableA();
        }
        private void PushData(DbRecord[] records)
        {
            db.InsertIntoTableB(records);
        }
    }
