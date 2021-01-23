        public MainPage()
        {
            InitializeComponent();
            bool canPlayMusic = true;
            FrameworkDispatcher.Update();
            if (!MediaPlayer.GameHasControl)
            {
                if (MessageBox.Show("Is it ok to stop currently playing music?",
                    "Can stop music?", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    canPlayMusic = false;
                }
            }
            if (canPlayMusic)
            {
                MediaPlayer.Pause();
                runBackgroundMusic();
            }
        }
