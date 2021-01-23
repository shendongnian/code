    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    private void timer1_Tick(object sender, EventArgs e)
    {
        sw.Start();
        this.Text = sw.Elapsed.ToString();
    }
