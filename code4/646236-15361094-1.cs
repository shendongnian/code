    private void end_Click(object sender, EventArgs e)
    {
        stopWatch.Stop();
    }
    private void button1_Click(object sender, EventArgs e)
    {
         TimeSpan ts = stopWatch.Elapsed;  //Here you will get the time interval         
    }
