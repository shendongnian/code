    private void backgroundWorkerShowChanges_DoWork(object sender, System.ComponentModel.DoWorkEventArgs args)
    {
    	TimeSpan span = DateTime.Now.Date - dateTimePickerScheduleDate.Value.Date;
    	var dateOffset = (int)span.TotalDays;
    
    	holdChanges = GetChangesMade(dateOffset, textBoxID.Text);
    }
