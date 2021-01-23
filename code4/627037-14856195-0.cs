    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<int> positions = new List<int>();
            bool checkNext = false;
            int position = -1;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("to");
            dataTable.Columns.Add("from");
            dataTable.Columns.Add("heading");
            dataTable.Columns.Add("body");
            var rs = new XmlReaderSettings();
            rs.IgnoreWhitespace = true;
            using (var reader = XmlReader.Create(File.OpenRead("data.xml"), rs))
            {
                while (reader.Read())
                {
                    if (reader.Name == "")
                    {
                        list.Add(reader.Value);
                        position++;
                    }
                    if (checkNext)
                    {
                        // TODO: apply your filter
                        if (reader.Value.ToLower().StartsWith("j"))
                        {
                            positions.Add(position);
                        }
                    }
                    if (reader.Name == "from")
                    {
                        checkNext = !checkNext;
                    }
                }
            }
            foreach (int match in positions)
            {
                dataTable.Rows.Add(
                    list[match - 1],
                    list[match],
                    list[match + 1],
                    list[match + 2]);
            }
            //LoadListView(dataTable);  
        }
    }
