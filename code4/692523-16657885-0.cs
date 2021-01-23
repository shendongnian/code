    class TimerState
    {
        public string ServerName { get; set; }
        public string QueryType { get; set; }
        public int TimerIndex { get; set; }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        schedValues.schedTurns = 120 / schedValues.schedTimer;
        var stateObj = new TimerState
            { ServerName = "foo", QueryType = "bar", TimerIndex = C3MonitorApp.globalVars.tmrArray };
        schedquery[C3MonitorApp.globalVars.tmrArray] =
            new System.Threading.Timer(writeLog, stateObj, 1000, 0);
        C3MonitorApp.globalVars.tmrArray++;
    }
