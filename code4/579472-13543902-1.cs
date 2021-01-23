    private class Result
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    private Result lastResult;
    void wiimote_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
    {
        Result newResult = new Result {
            X = e.WiimoteState.AccelState.Values.X,
            Y = e.WiimoteState.AccelState.Values.Y,
            Z = e.WiimoteState.AccelState.Values.Z,
        } 
        lastResult = newResult;
    }
    void MainLoop()
    {
        DateTime nextResultTime = DateTime.Now.AddMilliseconds(10);
        while(true)
        {
            if (DateTime.Now >= nextResultTime)
            {
                AddResult(lastResult);
                nextResultTime = nextResultTime.AddMilliseconds(10);
            }
            else
            {
                Thread.Sleep(1);
            }
        }
    }
