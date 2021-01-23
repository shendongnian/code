        public class Record
        {
            public DateTime Date { get; set; }
            public int Value { get; set; }
        }
    
        public class Grouper
        {
            public IEnumerable<IEnumerable<Record>> GroupRecords(IEnumerable<Record> sortedRecords)
            {
                var groupedRecords = new List<List<Record>>();
                var recordGroup = new List<Record>();
                groupedRecords.Add(recordGroup);
    
                foreach (var record in sortedRecords)
                {
                    if (recordGroup.Count > 0 && recordGroup.First().Value != record.Value)
                    {
                        recordGroup = new List<Record>();
                        groupedRecords.Add(recordGroup);
                    }
    
                    recordGroup.Add(record);
                }
    
                return groupedRecords;
            }
        }
