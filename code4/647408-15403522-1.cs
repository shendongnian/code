    private List<DataObject> ParseFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            string headerLine = streamReader.ReadLine();
            Dictionary<int, int> columnDictionary = this.GetColumnDictionary(headerLine);
            string line;
            List<DataObject> dataObjects = new List<DataObject>();
            while ((line = streamReader.ReadLine()) != null)
            {
                var lineValues = line.Split('|');
                string statId = lineValues[columnDictionary[0]];
                dataObjects.Add(
                    new DataObject()
                    {
                        StatisticId = lineValues[columnDictionary[0]],
                        FileId = lineValues[columnDictionary[1]],
                        ObjectId = lineValues[columnDictionary[2]],
                        Status = lineValues[columnDictionary[3]]
                    }
                );
            }
            return dataObjects;
        }
