            DateTime dtStart = new DateTime(2012, 11, 1);
            DateTime dtEnd = new DateTime(2012, 11, 7);
            for (int i = 0; i < dtEnd.Subtract(dtStart).Days; i++)
            {
                TimeSpan counter = new TimeSpan(i, 0, 0, 0);
                dataGridView1.Columns.Add(string.Format("col{0}", i), (dtStart + counter).DayOfWeek.ToString());
            }  
