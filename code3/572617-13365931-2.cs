                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
    
                dt1.Columns.Add("termid", typeof(Int32));
                dt1.Columns.Add("faultid", typeof(Int32));
                dt1.Columns.Add("faultdesc");
                dt2.Columns.Add("termid", typeof(Int32));
                dt2.Columns.Add("faultid", typeof(Int32));
    
                dt1.Rows.Add(1,2,"desc");
                dt1.Rows.Add(3, 4, "desc");
                dt1.Rows.Add(5, 6, "desc");
                dt2.Rows.Add(1, 2);
                dt2.Rows.Add(3, 4);
                dt2.Rows.Add(7, 8);
    
                var view = new DataView(dt1);
                DataTable dt3 = view.ToTable(true, "termid", "faultid");
                var diff =dt2.AsEnumerable().Except(dt3.AsEnumerable(), DataRowComparer.Default);
    
                foreach (var row in diff)
                {
                    Console.WriteLine(row["termid"] + " " + row["faultid"]);
                }
