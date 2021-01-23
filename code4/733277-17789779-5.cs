    DateTime date = DateTime.Parse("July 22, 2013");
            DayOfWeek dateDay = date.DayOfWeek;
            DayOfWeek[] possibleDays = { DayOfWeek.Tuesday,DayOfWeek.Wednesday,DayOfWeek.Friday };
            int addToBestAnswer = 7;
            foreach (var checkDay in possibleDays)
            {
                if (checkDay-dateDay<addToBestAnswer)
                {
                    addToBestAnswer = checkDay - dateDay;
                }
            }
            DateTime Answer = date.AddDays(addToBestAnswer);
