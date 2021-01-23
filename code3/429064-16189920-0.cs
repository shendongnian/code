		int[] getAge(DateTime dt)
        {
            DateTime today = DateTime.Now;
            int years = 0;
            int days = 0;
            int months = 0;
            int[] age = new int[3];
            while (dt.Year != today.Year || dt.Month != today.Month || dt.Day != today.Day)
            {
                if (dt.AddYears(1).CompareTo(today) <= 0)
                {
                    years++;
                    dt = dt.AddYears(1);
                }
                else
                {
                    if (dt.AddMonths(1).CompareTo(today) <= 0)
                    {
                        months++;
                        dt = dt.AddMonths(1);
                    }
                    else
                    {
                        if (dt.AddDays(1).CompareTo(today) <= 0)
                        {
                            days++;
                            dt = dt.AddDays(1);
                        }
                        else
                        {
                            dt = today;
                        }
                    }
                }
            }
            age[0] = years;
            age[1] = months;
            age[2] = days;
            return age;
        }
