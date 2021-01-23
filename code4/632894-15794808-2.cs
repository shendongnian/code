        private void StopMedia(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }
        private void PauseMedia(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }
        private  void PlayMedia(object sender, RoutedEventArgs e)
        {
            media.Source = new Uri(this.BaseUri, "Assets/page1/para1.mp3");
            media.Play();
        }
        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            media.MediaEnded += media_MediaEnded;
            
        }
        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Source = new Uri(this.BaseUri, "Assets/page1/para2.mp3");
            media.Play();
        }
