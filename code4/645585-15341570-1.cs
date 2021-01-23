    private void Browse_Click(object sender, EventArgs e)
    {
        OpenFileDialog tarik = new OpenFileDialog();
        tarik.Title = "Browse...";
        tarik.InitialDirectory = @"Desktop";
        tarik.Filter = "Wav files (*.wav)|*.wav";
        tarik.RestoreDirectory = true;
        if (tarik.ShowDialog() == DialogResult.OK) {
            textBox1.Text = tarik.FileName;
        }
    }
    
    private void Play_Click(object sender, EventArgs e)
    {
            using(Stream tarik2 = File.Open(textBox1.Text, FileMode.Open))
            {
                SoundPlayer snd = new SoundPlayer(tarik2);
                snd.Play();
            }
    }
