    class DbResult
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DB_FIELD { get; set; }
    }
    
    var result = _dbContext.Database.SqlQuery<DbResult>(
                     "select ID, NAME, DB_FIELD from eis_hierarchy");
