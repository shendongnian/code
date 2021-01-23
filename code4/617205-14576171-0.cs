    private void SetIntervalButton_Click(object sender, EventArgs e)
    {
        int interval = 0;
        bool success = Int32.TryParse(intervalTextBox.Text, out interval);
    
        if(success)
        {
            operationTimer.Interval = interval;
        }
    }
