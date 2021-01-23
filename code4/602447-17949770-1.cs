    [Table]  // Look no name
    public class DbRecord
    {
        [Column(IsPrimaryKey=true)]
        public long Id { get; set; }
    }
    CustomDataContext.UpdateCustomTable(typeof(DbRecord), "DbTable");
    using (CustomDataContext dc = new CustomDataContext(dbConnection))
    {
        Table<DbRecord> dbTable = dc.GetTable<DbRecord>();
        var query = from item in dbTable;
    }
