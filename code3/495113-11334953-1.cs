    public void button1_Click(object sender, EventArgs e)
    {
        timer1.Enabled = true;
    }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            filePaths = Directory.GetFiles(directpath, "*.wav");
            if (counter < filePaths.Length)
            {
                label1.Text = filePaths[counter];
                SoundPlayer simpleSound = new SoundPlayer(filePaths[counter]);
                simpleSound.Play();
                counter++;
            }
    
        }
