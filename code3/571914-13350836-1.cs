                DataTable dt = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns["Column1"].DataType = typeof(Int32);
                dt.Rows.Add(1);
                dt.Rows.Add(2);
                dt.Rows.Add(-1);
                int a = Convert.ToInt32(dt.Compute("SUM(Column1)", "Column1>0"));
                Console.WriteLine(a);  //Will print 3
