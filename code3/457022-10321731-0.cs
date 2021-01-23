            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            table1.Columns.Add("id", typeof(int));
            table1.Columns.Add("name", typeof(string));
            table2.Columns.Add("id", typeof(int));
            table2.Columns.Add("age", typeof(int));
            table1.Rows.Add(1, "mitja");
            table1.Rows.Add(2, "sandra");
            table1.Rows.Add(3, "nataška");
            table2.Rows.Add(1, 31);
            table2.Rows.Add(3, 24);
            table2.Rows.Add(4, 46);
            DataTable targetTable = table1.Clone();
            //create new column
            targetTable.Columns.Add("age");
            var results = from t1 in table1.AsEnumerable()
                          join t2 in table2.AsEnumerable() on t1.Field<int>("id") equals t2.Field<int>("id")
                          select new
                          {
                              ID = (int)t1["id"],
                              NAME = (string)t1["name"],
                              AGE = (int)t2["age"]
                          };
            foreach (var item in results)
                targetTable.Rows.Add(item.ID, item.NAME, item.AGE);
