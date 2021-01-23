    private void dispatchTimer_Tick(object sender, EventArgs e)
    {
        string wTime = DateTime.Now.ToString("HH:mm:ss");
        // OR THIS WAY
        string wTime2 = DateTime.Now.ToString("T");
        label1.Content = wTime;
        textBlock1.Text = wTime;
        button1.Content = wTime;
    }
