    public class Thing {
        public string ID { get; set; }
        
        public DateTime LastUpdated { get; set; }
        public DateTime LastPulled { get; set; }
        // to match the dbo.TempTable User-Defined Table Type on database
        private static readonly SqlMetaData[] myRecordSchema = {
            new SqlMetaData("id", SqlDbType.VarChar, 50),
            new SqlMetaData("lastUpdated", SqlDbType.DateTime),
            new SqlMetaData("lastPulled", SqlDbType.DateTime),
        };
        public SqlDataRecord ToSqlDataRecord() {
            var record = new SqlDataRecord(myRecordSchema);
            record.SetString(0, ID);
            record.SetDateTime(1, LastUpdated);
            record.SetDateTime(2, LastPulled);
            return record;
        }
    }
