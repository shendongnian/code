    DateTime date = DateTime.Parse("July 22, 2013");
            string[] possibleDays={ "Tuesday","Wednesday","Friday" };
            List<int> pDays = new List<int>();
            foreach (var inputDay in possibleDays)
            {
                pDays.Add(int.Parse(inputDay.Replace("Sunday", "0").Replace("Monday", "1").Replace("Tuesday", "2").Replace("Wednesday", "3").Replace("Thursday", "4").Replace("Friday", "5").Replace("Saturday", "6")));
            }
            int dateDay = (int)date.DayOfWeek;
            
            int addToBestAnswer = 7;
            foreach (var checkDay in pDays)
            {
                int difference = checkDay - dateDay;
                if (difference<0)
                {
                    difference = 7 + difference;
                }
                if (difference<addToBestAnswer&&difference!=0)
                {
                    addToBestAnswer = difference;
                }
            }
            DateTime Answer = date.AddDays(addToBestAnswer);
            // Answer.ToShortDateString()+" ("+Answer.DayOfWeek.ToString()+")";
