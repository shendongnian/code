    DateTime theDay = dateTimePicker1.Value;
    
    private void timer1_Tick(object sender, EventArgs e)
    {
    	if (DateTime.Now.CompareTo(theDay) > 0 ) // checks if now is after theDay
    	{
			theDay = DateTime.MaxValue;
			// makes sure there wont be multiple MessageBox due to event queuing
			// you could also just stop the timer here
			MessageBox.Show ("Reminder");
    	}
    }
