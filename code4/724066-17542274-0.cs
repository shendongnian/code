    //A PROPERTY THAT SAVES SELECTED DATE VALUE
    public DateTime SelectedDate {get;set;}
    //A METHOD THAT SHOWS ACTIVITY 
    public void ShowActivity(DateTime date) {
        DayView Activity = new DayView(date);
        Activity.Show();
        this.Hide();
    }
    public void calItemSelectedDate(object sender, SelectionChangedEventArgs e)
    {
        DateTime d;
        if (sender is DateTime)
        {
            d = (DateTime)sender;
        }
        else
        {
            DateTime.TryParse(sender.ToString(), out d);
        }
        SelectedDate = d;
      
        ShowActivity(d);
     }
