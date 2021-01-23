    DoubleAnimation _Animation;
        private Storyboard _StoryBoard;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimaiton(false);
            _StoryBoard.Pause();
        }
        private void LoadAnimaiton(bool up)
        {
            _StoryBoard = new Storyboard();
            _Animation = new DoubleAnimation(100.0, new Duration(TimeSpan.Parse("0:0:10")));
            _Animation.From = cnvMain.ActualHeight;
            _Animation.To = -Image1.ActualHeight;
            _Animation.RepeatBehavior = RepeatBehavior.Forever;
            _Animation.FillBehavior = FillBehavior.Stop;
            Storyboard.SetTarget(_Animation, Image1);
            Storyboard.SetTargetProperty(_Animation, new PropertyPath(Canvas.BottomProperty));
            if (up)
            {
                _Animation.From = cnvMain.ActualHeight;
                _Animation.To = -cnvMain.ActualHeight;
            }
            else
            {
                _Animation.From = -cnvMain.ActualHeight;
                _Animation.To = cnvMain.ActualHeight;
            }
            
            _StoryBoard.Children.Add(_Animation);
            _StoryBoard.Begin();
        }
        public void Pause()
        {
            _StoryBoard.Pause();
        }
        public void Down()
        {
            LoadAnimaiton(true);
        }
        public void Up()
        {
            LoadAnimaiton(false);
        }
