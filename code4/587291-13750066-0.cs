                var dynamicList = new List<dynamic>();
                DataTable dt = new DataTable();
                dt.Columns.Add("Col1");
                dt.Columns.Add("Col2");
                dt.Rows.Add("val1","val2");
                dt.Rows.Add("val3", "val4");
                foreach (DataRow dr in dt.Rows)
                {
                    dynamic myObj = new ExpandoObject();
                    var p = myObj as IDictionary<string, object>;
                    p[dr.Table.Columns[0].ColumnName] = dr[0];
                    p[dr.Table.Columns[1].ColumnName] = dr[1];
                    dynamicList.Add(p);
                }
    
                foreach (var item in dynamicList)
                {
                    Console.WriteLine(item.Col1 + " " + item.Col2);
                }   
