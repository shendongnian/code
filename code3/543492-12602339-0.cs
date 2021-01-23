    private void Form1_Deactivate(object sender, EventArgs e)
    {
        t = new System.Threading.Timer(new System.Threading.TimerCallback(t_Tick), null, 0, 100);
    }
    private void Form1_Activated(object sender, EventArgs e)
    {
        t.Dispose();
    }
    void t_Tick(object sender)
    {
        pictureBox1.Invoke((Action)delegate()
        {
            pictureBox1.Update();
        });
    }
