    private void start_Vid_Click(object sender, EventArgs e)
    {
        if (video.State != StateFlags.Running)
        {
            viewport.Visible = true;
            video.Play();
        }
    
        myTimer.Tick += (o,ea) => {    
            viewport.Visible = false;
            viewport2.Visible = true;
            pictureBox1.Visible = true;
            start_Webc(); 
            video2.Play();
            myTimer.Stop();
        }
        myTimer.Interval = 5000; // 5 seconds
        myTimer.Start();
    }
    
