     int i = 0;
     private void button1Sound(object sender, MouseEventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"file.wav");
    
            if (i == 0)
            {
                simpleSound.Play();
                i++;
            }
    
           else if (i >= 1)
            {
                simpleSound.Stop();
                i--;
            }
        }
