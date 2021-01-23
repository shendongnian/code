    public class Thing {
        public string A { get; set; }
        
        public string B { get; set; }
        public string C { get; set; }
        // to match the dbo.TempTable User-Defined Table Type on database
        private static readonly SqlMetaData[] myRecordSchema = {
            new SqlMetaData("A", SqlDbType.VarChar, 50),
            new SqlMetaData("B", SqlDbType.VarChar, 50),
            new SqlMetaData("C", SqlDbType.VarChar, 500)
        };
        public SqlDataRecord ToSqlDataRecord() {
            var record = new SqlDataRecord(myRecordSchema);
            record.SetString(0, A);
            record.SetDateTime(1, B);
            record.SetDateTime(2, C);
            return record;
        }
    }
