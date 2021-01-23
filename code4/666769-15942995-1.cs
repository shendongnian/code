    string[] schedule = { "Thursday 2:47 PM", "Thursday 2:50 PM", "Thursday 2:55 PM" };
    private void timer1_Tick(object sender, EventArgs e)
    {
        DateTime dateValue;
        foreach (var i in schedule)
        {
            if (DateTime.TryParseExact(i, "dddd h:mm tt", CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out dateValue))
            {
                var currentDate = DateTime.Now;
                if (dateValue.DayOfWeek == currentDate.DayOfWeek && dateValue.TimeOfDay == currentDate.TimeOfDay)
                {
                    //do something here
                }
            }
        }
    }
    
    private void Form1_Shown(object sender, EventArgs e)
    {
        timer1.Start();
    }
