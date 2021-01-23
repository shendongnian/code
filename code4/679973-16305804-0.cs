    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        TestObject obj = new TestObject();
        obj.Request = webResponse();
        stopwatch.Stop();
        obj.Time = stopwatch.Ellapsed.ToString();
        e.Result = obj;
    }
