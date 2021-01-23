            DaysOfWeek DaysToRun = DaysOfWeek.Friday | DaysOfWeek.Monday;
            TimeSpan timeToRun = new TimeSpan(12,0,0);
            DateTime now = DateTime.Today;
            DaysOfWeek Day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), now.DayOfWeek.ToString());
            if (DaysToRun.HasFlag(Day))
            {
                if (now.TimeOfDay < timeToRun )
                {
                    MessageBox.Show(nowTime.ToString());
                }
                else
                {
                    //return next day
                }
            }
            else
            {
                //return next day
            }
