     private List<DateTime> GetLastFridays()
     {
            List<DateTime> lstLastFridays = new List<DateTime>();
            TimeSpan oTimeSpan = new TimeSpan(((int)DateTime.Now.DayOfWeek + 2), 0, 0, 0, 0);
            DateTime dt = DateTime.Now.Subtract(oTimeSpan);
            lstLastFridays.Add(dt);
            for (int count = 0; count < 6; count++)
            {
                dt = dt.Subtract(new TimeSpan(7, 0, 0, 0, 0));
                lstLastFridays.Add(dt);
            }
            return lstLastFridays;
     }
