            bool playing = false;
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.D1)
                {
                    if (!playing)
                    {
                        
                        player.Open(new Uri(yourURI));
                        player.Play();
                        playing = true;
                    }
                    else
                    {
                        player.Stop();
                        playing = false;
                    }
                }
            }
