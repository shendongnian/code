    protected void Page_Load(object sender, EventArgs e)
    {
        var timer = System.Diagnostics.Stopwatch.StartNew();
        // sleep for 2.5s
        Thread.Sleep(2500);
        timer.Stop();
        var elapsed = timer.Elapsed;
        Result.Text = elapsed.ToString("mm':'ss':'fff");
    }
