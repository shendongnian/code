    sealed class MyImporter : IDisposable
    {
        [ThreadStatic] private DbInterface db;
        public MyImporter()
        {
            db = new DbInterface();
        }
        public void ImportAllData()
        {
            var records = PullData();
            PushData(records);
        }
        public void Dispose()
        {
            db.Dispose();
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
