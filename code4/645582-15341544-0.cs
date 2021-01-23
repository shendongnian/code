    //new instance field.
    private string tarikFileName;
    private void Browse_Click(object sender, EventArgs e)
    {
        OpenFileDialog tarik = new OpenFileDialog();
        tarik.Title = "Browse...";
        tarik.InitialDirectory = @"Desktop";
        tarik.Filter = "Wav files (*.wav)|*.wav";
        tarik.RestoreDirectory = true;
        if (tarik.ShowDialog() == DialogResult.OK) {
            //store value in instance field
            tarikFileName = tarik.FileName;
            textBox1.Text = tarik.FileName;
            Stream tarik2 = tarik.OpenFile();
            SoundPlayer snd = new SoundPlayer(tarik2);
            snd.Play();
        }
    }
    
    private void Play_Click(object sender, EventArgs e)
    {
        if(tarikFileName != null)
        {
            Stream stream = File.OpenRead(tarikFileName);
            SoundPlayer snd = new SoundPlayer(stream);
            snd.Play();
        }
    }
