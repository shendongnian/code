        List<Tuple<MachineryRecord,MachineryRecord>> OverlapingRecords(IEnumerable<MachineryRecord> sortedRecords)
        {
            var result = new List<Tuple<MachineryRecord, MachineryRecord>>();
            MachineryRecord prev = null;
            foreach (var current in sortedRecords)
            {
                if (prev != null)
                {
                    if (current.StartTime < prev.EndTime) { result.Add(new Tuple<MachineryRecord, MachineryRecord>(prev,current)); }
                }
                prev = current;
            }
            return result;
        }
