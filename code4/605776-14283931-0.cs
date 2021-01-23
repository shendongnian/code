        static void Main()
        {
            //create a data table and add the column's
            DataTable table = new DataTable("table_name");
            table.Columns.Add("name", typeof (String));
            table.Columns.Add("id", typeof (Int32));
            table.Columns.Add("place", typeof (String));
            //start reading the textfile
            StreamReader reader = new StreamReader("file_to_read");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split('\t');
                //make sure it has 3 items
                if (items.Length == 3)
                {
                    DataRow row = table.NewRow();
                    row["name"] = items[0];
                    row["id"] = Int32.Parse(items[1]);
                    row["place"] = items[2];
                    table.Rows.Add(row);
                }
            }
            reader.Close();
            reader.Dispose();
            // make use of the table
            // when use is done dispose it
            table.Dispose();
        }
