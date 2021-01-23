        public List<Dictionary<string, string>> LoadCsvAsDictionary(string path)
        {
            var result = new List<Dictionary<string, string>>();
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            System.IO.StreamReader file = new System.IO.StreamReader(fs);
            string line;
            int n = 0;
            List<string> columns = null;
            while ((line = file.ReadLine()) != null)
            {
                var values = SplitCsv(line);
                if (n == 0)
                {
                    columns = values;
                }
                else
                {
                    var dict = new Dictionary<string, string>();
                    for (int i = 0; i < columns.Count; i++)
                        if (i < values.Count)
                            dict.Add(columns[i], values[i]);
                    result.Add(dict);
                }
                n++;
            }
            file.Close();
            return result;
        }
        private List<string> SplitCsv(string csv)
        {
            var values = new List<string>();
            int last = -1;
            bool inQuotes = false;
            int n = 0;
            while (n < csv.Length)
            {
                switch (csv[n])
                {
                    case '"':
                        inQuotes = !inQuotes;
                        break;
                    case ',':
                        if (!inQuotes)
                        {
                            values.Add(csv.Substring(last + 1, (n - last)).Trim(' ', ','));
                            last = n;
                        }
                        break;
                }
                n++;
            }
            if (last != csv.Length - 1)
                values.Add(csv.Substring(last + 1).Trim());
            return values;
        }
