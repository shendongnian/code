    public void AnimateProgBar (int milliSeconds)
    {
        if (!timer1.Enabled)  {
            progressBar1.Value = 0;
            timer1.Interval = milliSeconds / 100;
            timer1.Enabled = true;
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if (progressBar1.Value < 100) {
            progressBar1.Value += 1;
            progressBar1.Refresh();
        } else {
            timer1.Enabled = false;
        }
    }
