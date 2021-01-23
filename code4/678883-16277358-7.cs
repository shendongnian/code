    private void timer1_Tick(object sender, EventArgs e)
    {
        timerTicks++;
        if (timerTicks > waitUntill)
        {
            timer1.Stop();
            backgroundWorker1.RunWorkerAsync();
        }
    }
