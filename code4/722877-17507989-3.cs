    private void KeyPressedOnce_PlaySound(object sender, EventArgs e)
    {
        if (currentKey == Keys.A)
        { 
            MediaPlayer p1 = new MediaPlayer();
            p1.Open(new System.Uri(wav1Path));
            p1.Play();
        }
        
        if (currentKey == Keys.S)
        {
            MediaPlayer p2 = new MediaPlayer();
            p2.Open(new System.Uri(wav2Path));
            p2.Play();
        }
    }
