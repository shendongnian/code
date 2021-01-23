    private System.Media.SoundPlayer sound;
    private bool isPlaying = false;
    private System.Drawing.Image playimage = System.Drawing.Image.FromFile(@"playimage");
    private System.Drawing.Image stopimage = System.Drawing.Image.FromFile(@"stopimage");
    private void playstopbutton_Click(object sender, EventArgs e)
    {
        Button btn = (sender as Button);
        if (isPlaying)
        {
            sound.Stop();
            isPlaying = false;
            btn.Text = "Play";
            btn.Image = playimage;
        }
        else if (sound.IsLoadCompleted)
        {
            sound.Play();
            isPlaying = true;
            btn.Text = "Stop";
            btn.Image = stopimage;
        }
        else
        {
            btn.Enabled = false;
            if (sound == null) sound = new System.Media.SoundPlayer(@"wavefile");
            sound.LoadCompleted += new AsyncCompletedEventHandler(sound_LoadCompleted);
            sound.LoadAsync();
        }
    }
    private void sound_LoadCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.playstopbutton.Text = "Stop";
        this.playstopbutton.Image = playimage;
        this.playstopbutton.Enabled = true;
        isPlaying = true;
        sound.Play();
    }
