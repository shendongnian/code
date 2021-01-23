    public static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        string GenData = "Welcome";
        form1.TboxData.AppendText(GenData.ToString());
    }
