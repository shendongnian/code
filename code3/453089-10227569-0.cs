    // to display
    foreach(var day in days)
    {
        ListBoxItem lbi = new ListBoxItem();
        TextBlock tb = new TextBlock();
        tb.Text = day.ToString();
        
        lbi.Content = tb;
        lbi.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
        lbi.IsSelected = AlarmMod.AlarmData.SelectedDays.Contains(day);
        
        this.listBox.Items.Add(lbi);
    }
 
    // to store
    List<DayOfWeek> iDays = new List<DayOfWeek>();
    
    for (int i = 0; i < 7; i++)
    {
        if ((this.listBox.Items[i] as ListBoxItem).IsSelected)
        {
            iDays.Add((DayOfWeek)i);
        }
    }
