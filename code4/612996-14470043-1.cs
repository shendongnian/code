    private static String threadingLock = "";
    
    private void bgPlay_DoWork(object sender,DoWorkEventArgs e)
        {
    
            while (true)
            {
                lock(threadingLock) {
                    if(!isMediaPlaying)
                        break;
                }
                this.Dispatcher.Invoke((Action)(() =>
                {
                    timelineSlider.Value = mediaElement1.Position.TotalMilliseconds;
                }));
    
            }
        }
    
        private void Library_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                lock(threadingLock) {
                    isMediaPlaying = false;
                }
                mediaElement1.Stop();
                
                mediaElement1.Source = new Uri(songData[Library.SelectedIndex].Location);
                mediaElement1.Volume = (double)volumeSlider.Value;
    
                mediaElement1.Play();
    
                isMediaPlaying = true;
    
                bgPlay.RunWorkerAsync();
            }
            catch(Exception ex) {
                F.MessageBox.Show(ex.ToString());
            }
        }
