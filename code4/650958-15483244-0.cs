    private List<System.Timers.Timer> timers = new List<System.Timers.Timer>();
    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        var myTimer = new System.Timers.Timer();
        myTimer.Interval = 30000;
        myTimer.Elapsed += new EventHandler(MyTimer_Tick);
        myTimer.Enabled = true;
        timers.Add(myTimer);
    }
