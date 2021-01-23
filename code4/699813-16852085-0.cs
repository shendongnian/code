    public void calItemSelectedDate(object sender, SelectionChangedEventArgs e)
    {
        Calendar cal = (Calendar)sender; 
        DateTime d = cal.SelectedDate;
        a.fetchAndPopulateForDate(d); <------I want code here.
        // ...
    }
