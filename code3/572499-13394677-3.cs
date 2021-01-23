    public static void SqlTestInfo()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            DisplayData(table);
        }
        private static void DisplayData(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn dataColumn in table.Columns)
                {
                    Console.WriteLine("{0} = {1}", dataColumn.ColumnName, row[dataColumn]);
                }
                Console.WriteLine();
            }
        }
