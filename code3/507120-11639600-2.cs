    private void button20_Click(object sender, RoutedEventArgs e)
    {
        // This block sets the TextBlock to a sensible default if dates haven't been picked
        if(!datePicker1.SelectedDate.HasValue || !datePicker2.SelectedDate.HasValue)
        {
            textBlock10.Text = "Select dates";
            return;
        }
        // Because the nullable SelectedDate properties must have a value to reach this point, 
        // we can safely reference them - otherwise, these statements throw, as you've discovered.
        DateTime start = datePicker1.SelectedDate.Value.Date;
        DateTime finish = datePicker2.SelectedDate.Value.Date;
        TimeSpan difference = finish.Subtract(start);
        textBlock10.Text = difference.TotalDays.ToString();
    }
