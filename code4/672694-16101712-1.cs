    public MainWindow()
            {
                _motDansTweet = new Dictionary<ObjetFollowingFollowerFinal, int>();
                _motDansTweet.Add(new ObjetFollowingFollowerFinal { Username = "Karl1" }, 1);
                _motDansTweet.Add(new ObjetFollowingFollowerFinal { Username = "Karl2" }, 2);
                _motDansTweet.Add(new ObjetFollowingFollowerFinal { Username = "Karl3" }, 3);
                _motDansTweet.Add(new ObjetFollowingFollowerFinal { Username = "Karl4" }, 4);
    
                Resources["MotDansTweet"] = MotDansTweet;
    
                InitializeComponent();
            }
