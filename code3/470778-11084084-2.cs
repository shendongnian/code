    SQLiteBulkInsertHelper ContactBlk = new SQLiteBulkInsertHelper("<SQLiteConnection>","<Table Name>");
    ContactBlk.AllowBulkInsert = true;
    ContactBlk.AddParameter("<Column Name>", /*Column Data Type*/System.Data.DbType.Int64);
    ContactBlk.AddParameter("<Column Name>", /*Column Data Type*/System.Data.DbType.String);
    ContactBlk.Insert(new object[] {<First Column Value>,<Second Column Value>});
    ContactBlk.Flush();
