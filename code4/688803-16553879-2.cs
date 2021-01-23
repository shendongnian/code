        public static void TestDates()
        {
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures).Where((x)=>!x.IsNeutralCulture && x.Calendar.AlgorithmType == CalendarAlgorithmType.SolarCalendar))
            {
                for (int year = 2010; year < 2040; year++)
                {
                    // first try a bunch of hours in this year
                    // convert from date -> week -> date
                    for (int hour = 0; hour < 356 * 24; hour+= 6)
                    {
                        DateTime dt = new DateTime(year, 1, 1).AddHours(hour);
                        int ww;
                        int wyear;
                        Gener8.SerialNumber.GetWeek(dt, ci, out ww, out wyear);
                        if (wyear != year)
                        {
                            //Console.WriteLine("{0} warning: {1} {2} {3}", ci.Name, dt, year, wyear);
                        }
                        DateTime dt1 = Gener8.SerialNumber.FirstDateOfWeek(wyear, ww, ci);
                        DateTime dt2 = Gener8.SerialNumber.FirstDateOfWeek(wyear, ww, ci).AddDays(7.0);
                        if (dt < dt1 || dt > dt2)
                        {
                            Console.WriteLine("{3} Bad date {0} not between {1} and {2}", dt, dt1, dt2, ci.Name);
                        }
                    }
 
                    // next try a bunch of weeks in this year
                    // convert from week -> date -> week
                    for (int week = 1; week < 54; week++)
                    {
                        DateTime dt0 = FirstDateOfWeek(year, week, ci);
                        int ww0;
                        int wyear0;
                        GetWeek(dt0, ci, out ww0, out wyear0);
                        DateTime dt1 = dt0.AddDays(6.9);
                        int ww1;
                        int wyear1;
                        GetWeek(dt1, ci, out ww1, out wyear1);
                        if ((dt0.Year == year && ww0 != week) ||
                            (dt1.Year == year && ww1 != week))
                        {
                            Console.WriteLine("{4} Bad date {0} ww0={1} ww1={2}, week={3}", dt0, ww0, ww1, week, ci.Name);
                        }
                    }
                }
            }
        }
