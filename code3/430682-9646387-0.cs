    using Coding4Fun.Phone.Controls.Toolkit;
	private void DateTimeButton_Click(object sender, RoutedEventArgs e)
	{
		TimeSpan TimeSpanDuration = TimeSpan.FromMilliseconds(status.duration);
		_TimeSpanPicker.Max = new TimeSpan(TimeSpanDuration.Hours, TimeSpanDuration.Minutes, TimeSpanDuration.Seconds);
		_TimeSpanPicker.Step = new TimeSpan(0, 0, 1);
		_TimeSpanPicker.OpenPicker();
	}
	private void _TimeSpanPicker_ValueChanged(object sender, ValueChangedEventArgs<TimeSpan> e)
	{
		MessageBox.Show(_TimeSpanPicker.Value.ToString());
	}
