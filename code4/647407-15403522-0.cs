    private Dictionary<int, int> GetColumnDictionary(string headerLine)
        {
            Dictionary<int, int> columnDictionary = new Dictionary<int, int>();
            List<string> columnNames = headerLine.Split('|').ToList();
            string maxTierObjectColumnName = GetMaxTierObjectColumnName(columnNames);
            for (int index = 0; index < columnNames.Count; index++)
            {
                if (columnNames[index] == "StatisticID")
                {
                    columnDictionary.Add(0, index);
                }
                if (columnNames[index] == "FileId")
                {
                    columnDictionary.Add(1, index);
                }
                if (columnNames[index] == maxTierObjectColumnName)
                {
                    columnDictionary.Add(2, index);
                }
                if (columnNames[index] == "Status")
                {
                    columnDictionary.Add(3, index);
                }
            }
            return columnDictionary;
        }
        private string GetMaxTierObjectColumnName(List<string> columnNames)
        {
            // Edit this function if Tier ObjectId is greater then 9
            var maxTierObjectColumnName = columnNames.Where(c => c.Contains("Tier") && c.Contains("Object")).OrderBy(c => c).Last();
            return maxTierObjectColumnName;
        }
