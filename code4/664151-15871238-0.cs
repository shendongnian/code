     //Get Start And End
                int delta = Convert.ToInt32(DateTime.Now.DayOfWeek);
                delta = delta == 0 ? delta + 7 : delta;
                DateTime moday = DateTime.Now.AddDays(1 - delta);
                DateTime sunday = DateTime.Now.AddDays(7 - delta);
                //Get Date Range
                List<DateTime> allDates = new List<DateTime>();
                //Add To Your List
                for (DateTime i = moday; i <= sunday; i = i.AddDays(1))
                {
                    DropDownList1.Items.Add(i.Date.DayOfWeek);
                }
                //Select Today Name
                DropDownList1.SelectedItem = DateTime.Today.Date.DayOfWeek;
