    private Dictionary<DataGridViewRow, System.Timers.Timer> timers = new Dictionary<DataGridViewRow, System.Timers.Timer>();
    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        var myTimer = new System.Timers.Timer();
        myTimer.Interval = 30000;
        myTimer.Elapsed += new ElapsedEventHandler(MyTimer_Tick);
        myTimer.Enabled = true;
        // Potential bug source: If you programmatically add multiple rows at once,
        // a timer is only added to the first row
        timers.Add(dataGridView1.Rows[e.RowIndex], myTimer);
    }
