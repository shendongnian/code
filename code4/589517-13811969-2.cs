    var dt = new System.Data.DataTable();
    
                dt.Columns.Add("MyDate", typeof(DateTime));
                dt.Rows.Add(new DateTime(2012,1,10));
                dt.Rows.Add(new DateTime(2012,2,10));
    
                int month= DateTime.ParseExact("January", "MMMM", CultureInfo.CurrentCulture).Month;
                DateTime filterDateLower = new DateTime(DateTime.Now.Year, month, 1);
                DateTime filterDateUpper = filterDateLower.AddMonths(1);
                dt.DefaultView.RowFilter = "[MyDate] > #" + filterDateLower + "# and [MyDate] < #" + filterDateUpper +"#";
                foreach (DataRow d in dt.DefaultView.ToTable().Rows)
                {
                    Console.WriteLine(d["MyDate"].ToString());
                }
