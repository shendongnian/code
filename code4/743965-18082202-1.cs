    private void StartPicker_TextChanged(object sender, TextChangedEventArgs e)
    {
        TimePicker tp = sender as TimePicker;
        if(tp != null)
        {
            tp.Focus();
        }
    }
    
    private void EndPicker_TextChanged(object sender, TextChangedEventArgs e)
    {
        TimePicker tp = sender as TimePicker;
        if(tp != null)
        {
            tp.Focus();
        }
    }
