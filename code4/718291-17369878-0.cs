    private DateTime today;
    private void IsNextDay()
    {
        if (DateTime.Now.Substract(today.Date.AddDays(1)).TotalMilliseconds <= 0)
        {
            today = DateTime.Now; //Next Date so you can check every day
            
            //FireCustom-Event or do your work here
        }
    }
