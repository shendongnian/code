    string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    
    DateTime startDate = new DateTime(2013, 1, 1);
    DateTime endDate = new DateTime(2013, 3, 1);
        
    while (true)
    {
       dataGridView1.Columns.Add(months[startDate.Month - 1], months[startDate.Month - 1]);
       startDate = startDate.AddMonths(1);
       if (startDate > endDate)
           break;
    }
