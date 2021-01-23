    private SoundPlayer sp;
    private void button1_Click(object sender, EventArgs e)
    {     
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sp = new SoundPlayer(ofd.FileName);
                timer1.Start();
                sp.Play();
            }
    
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
            sp.Play();
    }
