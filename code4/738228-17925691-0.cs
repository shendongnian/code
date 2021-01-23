    private void dateTimePicker1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
    	if (e.OriginalSource is Xceed.Wpf.Toolkit.DateTimePicker)
    	{
    		DateTime date = (DateTime)datepicker.Value;
    		datepicker.Text = date.Date.ToString();
    		UpdateDateLabels(date);
    	}
    }
