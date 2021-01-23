    protected void button_click(object sender, EventArgs e)
      {
            DateTime dt = new DateTime(2013, 6, 1);
            string[] dates = getDates(dt);
       }
            public string[] getDates(DateTime dt)
        {
            string[] result = new string[7]; ;
            for (int i = getDay(dt.DayOfWeek.ToString()); i < 7; i++)
            {
                if (i == 0)
                {
                    break;
                }
                else
                {
                    dt = dt.AddDays(1);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                dt = dt.AddDays(1);
                result[i] = dt.ToShortDateString();
            }
            return result;
        }
        public int getDay(string day)
        {
            switch (day)
            {
                case "Monday":
                    return 0;
                case "Tuesday":
                    return 1;
                case "Wednesday":
                    return 2;
                case "Thursday":
                    return 3;
                case "Friday":
                    return 4;
                case "Saturday":
                    return 5;
                case "Sunday":
                    return 6;
                default:
                    return 0;
            }
        }## Heading ##
