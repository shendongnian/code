    List<string> selectedItemsDays = new List<string> { };
                if (alertDayInt >= 1000000)
                {
                    selectedItemsDays.Add("Mon");
                    alertDayInt -= 1000000;
                }
                if (alertDayInt >= 100000)
                {
                    selectedItemsDays.Add("Tue");
                    alertDayInt -= 100000;
                }
                if (alertDayInt >= 10000)
                {
                    selectedItemsDays.Add("Wed");
                    alertDayInt -= 10000;
                }
                if (alertDayInt >= 1000)
                {
                    selectedItemsDays.Add("Thu");
                    alertDayInt -= 1000;
                }
                if (alertDayInt >= 100)
                {
                    selectedItemsDays.Add("Fri");
                    alertDayInt -= 100;
                }
                if (alertDayInt >= 10)
                {
                    selectedItemsDays.Add("Sat");
                    alertDayInt -= 10;
                }
                if (alertDayInt >= 1)
                {
                    selectedItemsDays.Add("Sun");
                    alertDayInt -= 1;
                }
