        public static DataTable ParseCSV(string path)
        {
            var dt = new DataTable();
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] items = line.Split('\t');
                    items[1] = ToUpperFirstLetter(items[1].ToLower());
                    if (dt.Columns.Count == 0)
                    {
                        // column names
                        foreach (string t in items)
                            dt.Columns.Add(new DataColumn(t.Trim(), typeof(string)));
                    }
                    else
                    {
                        //data
                        dt.Rows.Add(items);
                    }
                }
            }
            return dt;
        }
