    private SoundPlayer s;
    private void button1_Click(object sender, EventArgs e)
    {     
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            s = new SoundPlayer(ofd.FileName);
            timer1.Start();
            s.Play();
        }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        s.Play();
    }
