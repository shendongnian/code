    private bool startjob() //DateTime checking for DateValue and start's if correct value.
    {
    	DateTime? start = DateTimePicker1.Value;
    	DateTime? end = DateTimePicker2.Value;
    	DateTime now = DateTime.Now;
    	
    	if (start == null || end == null)
    	{
    		Xceed.Wpf.Toolkit.MessageBox.Show("one of the pickers is empty");
    	}
    	else if (now >= start.Value && now <= end.Value)
    	{
    		Process notePad = new Process();
    		
    		notePad.StartInfo.FileName = "notepad.exe";
    		
    		notePad.Start();
    		return true;
    	}
    	return false;
    }
