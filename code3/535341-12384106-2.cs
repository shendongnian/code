    public void playclick(object sender, EventArgs e)
    {
        int i, j;
        for (j = 0; j <= 7 - 1; j++)
        {
            for (i = 0; i <= 3 - 1; i++)
            {
                if (btnp[i, j].Capture)
                {
                    //play();
                    th[i, j] = new Thread(new ParameterizedThreadStart(play));
                    th[i, j].IsBackground = true;
                    th[i, j].Start(video[i,j]);
                }
            }
        }
    }
    public void play(object video)
    {
        Video vid = video as Video; 
        if (vid.State != StateFlags.Running)
        {
            vid.Play();
        }        
    }
