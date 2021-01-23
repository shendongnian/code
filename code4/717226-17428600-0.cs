        // Write data to a .csv file
        private void WriteToCSV(string data)
        {
            int length = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;
            // List of lists containing each line split by part
            List<List<string>> dataList = new List<List<string>>();
            List<string> valuesA = new List<string>();
            // Building the list
            foreach (string line in data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                List<string> partsLine = new List<string>();
                partsLine.AddRange(line.Split('\t'));
                dataList.Add(partsLine);
            }
            const string separator = ";";
            // Writing the list to the .csv file
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\output.xls", false))
                {
                    dataList.ForEach(line =>
                    {
                        var lineArray = line.Select(c => c.Contains(separator) ? c.Replace(separator.ToString(), "\\" + separator) : c).ToArray();
                        writer.WriteLine(string.Join(separator, lineArray));
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing data to .csv file (" + ex.Message + ")");
            }
