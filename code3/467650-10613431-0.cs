            //creating an example table with one row (no data inisde):
            DataTable table = new DataTable();
            table.Columns.Add("FullName", typeof(string));
            table.Rows.Add("");
            string str = ConvertNullToEmptyString(table);
        
        //method to check for string:
        private String ConvertNullToEmptyString(DataTable element)
        {
            String s = element.Rows[0]["FullName"].ToString();
            return (string.IsNullOrEmpty(s) ? "NO DATA" : s);
        }
