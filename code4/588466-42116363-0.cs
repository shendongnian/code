    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (FinalVideo != null)
    	{
    		if (FinalVideo.IsRunning)
    		{
    			FinalVideo.SignalToStop();
    			FinalVideo = null;
    		}
    	}
    }
