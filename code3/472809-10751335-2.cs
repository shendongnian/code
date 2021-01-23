    private void button1_Click(object sender, EventArgs e)
    {
        DateTime startDate = new DateTime(2012 , 05 , 25);
        DateTime endDate = new DateTime(2012 , 05 , 31);
        bool rtnval = IsValidDate(startDate, endDate);
    }
    public bool IsValidDate(DateTime startDate, DateTime endDate)
    {
        return startDate < endDate && endDate > startDate; 
    }
