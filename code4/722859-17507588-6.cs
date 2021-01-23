            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                   foreach (MediaPlayer m in myplayers)
                   {
                      m.Stop();
                   }
                   return;
                }
    
                if (sounds.ContainsKey(e.KeyCode))
                {
                    MediaPlayer mp = new MediaPlayer();
                    mp.Open(sounds[e.KeyCode]);
                    mp.Play();
                }
            }
