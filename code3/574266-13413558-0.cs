    for (int i = 0; i < dtEnd.Subtract(dtStart).Days; i++)
            {
                TimeSpan counter = new TimeSpan(i, 0, 0, 0);                                       
               dataGridView1.Columns.Add(string.Format("col{0}", i), string.Format("{0}", (dtStart + counter).DayOfWeek.ToString()));
            }
