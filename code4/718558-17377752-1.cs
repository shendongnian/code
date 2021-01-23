    // In the timepicker's time-changed event
    if (DateTime.Now.CompareTo(timepicker.Value) == 1 && DateTime.Now.Subtract(timepicker.Value).TotalMilliseconds > 15 * 60 * 1000)
    {
         // Do stuff!
         MessageBox.Show("You can only set a max of 15 minutes ahead of the current time!");
         // Cancel the event / set the timepicker's value back to the current time / whatever you prefer
         // One option:
         timepicker.Value = DateTime.Now;
    }
