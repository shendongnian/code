    private void timer1_Tick(object sender, System.EventArgs e)
    { 
        nextImage();
    }
    
    private void Start_Click(object sender, System.EventArgs e)
    {
        if(timer1.Enabled == true)
        { 
            timer1.Enabled = false;
            Start.Text = "<< START Slide Show >>";
        }
        else
        {
            timer1.Enabled = true;
            Start.Text = "<< STOP Slide Show >>";
        }
    }
