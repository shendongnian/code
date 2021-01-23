        private string[] GetPrimaryKeysofTable(string TableName)
        {
            string stsqlCommand = "SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                                  "WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1" +
                                  "AND table_name = '" +TableName+ "'";
            SqlCommand command = new SqlCommand(stsqlCommand, Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            string[] result = new string[table.Rows.Count];
            int i = 0;
            foreach (DataRow dr in table.Rows)
            {
                result[i++] = dr[0].ToString();
            }
           
            return result;
        }
