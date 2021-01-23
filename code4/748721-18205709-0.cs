    private void CollectDates()
    {
        DateTime StartDate = Convert.ToDateTime(txtFromDate.Text);
        DateTime EndDate = Convert.ToDateTime(txtTillDate.Text);
        List<DateTime> dateList = new List<DateTime>();
    
        DateTime currentDate = StartDate;
        
        while(currentDate <= EndDate)
        {
            dateList.Add(currentDate);
            currentDate.AddDays(1);
        }
    }
