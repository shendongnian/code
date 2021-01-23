            DispatcherTimer mediaTimer = new DispatcherTimer();
            mediaTimer.Interval = TimeSpan.FromMinutes(5);
            mediaTimer.Tick += new EventHandler(mediaTimer_Tick);
            mediaTimer.Start();
        void mediaTimer_Tick(object sender, EventArgs e)
        {
            nextMovie();
        }
        public void nextMovie()
        {
            if (mediaIndex >= 5)
                mediaIndex = 0;
            switch (mediaIndex)
            {
                case 0:
                    mediaElement1.Source = new Uri(videoFileName1, UriKind.Absolute);
                    break;
                case 1:
                    mediaElement1.Source = new Uri(videoFileName2, UriKind.Absolute);
                    break;
                case 2:
                    mediaElement1.Source = new Uri(videoFileName3, UriKind.Absolute);
                    break;
                case 3:
                    mediaElement1.Source = new Uri(videoFileName4, UriKind.Absolute);
                    break;
                case 4:
                    mediaElement1.Source = new Uri(videoFileName5, UriKind.Absolute);
                    break;
                default:
                    mediaElement1.Source = new Uri(videoFileName1, UriKind.Absolute);
                    break;
            }
            mediaElement1.Visibility = System.Windows.Visibility.Visible;
            mediaIndex++;
            mediaElement1.Play();
        }
