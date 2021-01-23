            bool endTomorrow = true;
            DateTime taskDate = new DateTime(2012, 08, 31);
            TimeSpan Start = new TimeSpan(03, 30, 00);
            TimeSpan End = new TimeSpan(01, 30, 00);
            DateTime currentTime = DateTime.Now;
            bool flag = false;
            if (currentTime.TimeOfDay >= Start)
            {
                if (endTomorrow)
                {
                    flag = currentTime.Date <= taskDate || (currentTime.Date == taskDate.AddDays(1) && currentTime.TimeOfDay < End);
                }
                else
                {
                    flag = currentTime.TimeOfDay < End;
                }
            }
            if (flag)
            {
                //do the task
            }
