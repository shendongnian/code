    [JsonConverter(typeof(ChartDataRecordCollectionConverter))]
    public class ChartDataRecordCollection : List<ChartDataRecord>
    {
        public ChartDataRecordCollection()
        {
        }
        public ChartDataRecordCollection(IEnumerable<ChartDataRecord> records)
        {
            AddRange(records);
        }
    }
