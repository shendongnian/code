     if (button1.Content.Equals("Play"))
                {
                    button1.Content = "Pause";
                    mediaElement1.Play();
                }
                else
                {
                    button1.Content = "Play";
                    mediaElement1.Pause();
                }
