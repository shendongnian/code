            string[] result = new string[table.Columns.Count];
            DataRow dr = table.Rows[0];
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                result[i] = dr[i].ToString();
            }
            foreach (string str in result)
                Console.WriteLine(str);
</pre>
