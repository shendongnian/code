       protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Rows.Add(DateTime.Today);
                dt.Rows.Add(DateTime.Today.AddDays(10));
                dt.Rows.Add(DateTime.Today.AddDays(12));
                dt.Rows.Add(DateTime.Today.AddDays(8));
                dt.Rows.Add(DateTime.Today.AddDays(6));
                dt.Rows.Add(DateTime.Today.AddDays(9));
                dt.Rows.Add(DateTime.Today.AddDays(2));
                dt.Rows.Add(DateTime.Today.AddDays(1));
                dt.Rows.Add(DateTime.Today.AddDays(3));
                DateTime date = e.Day.Date;
                var query = from row in dt.AsEnumerable()
                        where row.Field<DateTime>("date") == date
                       select row;
                foreach (var d in query)
                {
                    e.Cell.BackColor = System.Drawing.Color.Red;
                }
           
        }
