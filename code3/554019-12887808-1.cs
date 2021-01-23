     int i = 0;
     SoundPlayer simpleSound = new SoundPlayer(@"file.wav"); //Thanks to @Wanabrutbeer
    
     private void button1Sound(object sender, MouseEventArgs e)
        {
            
    
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
