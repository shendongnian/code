            DataTable table = new DataTable();
            table.Columns.Add("Invoice", typeof(string));
            table.Columns.Add("Line", typeof(int));
            table.Columns.Add("Part", typeof(string));
            for (int i = 1; i <= 9; i++)
                table.Rows.Add("Invoice " + i, i, "Part " + i);
            //reorder them:
            int[] orders = { 6, 7, 8, 1, 2, 3, 4, 5 };
            DataTable table2 = table.Clone();
            DataRow row;
            for (int i = 0; i < orders.Length; i++)
            {
                row = table2.NewRow();
                row["Invoice"] = table.Rows[orders[i]]["Invoice"];
                row["Line"] = table.Rows[orders[i]]["Line"];
                row["Part"] = table.Rows[orders[i]]["Part"];
                table2.Rows.Add(row);
            }
