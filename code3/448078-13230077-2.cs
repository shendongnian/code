    GameTimer gameTime = new GameTimer();
    int _timer = 5;
    // initiate
    gameTime.UpdateInterval = TimeSpan.FromSeconds(1);  // game time count every second
    gameTime.Update +=new EventHandler<GameTimerEventArgs>(gameTime_Update);  // each time count, will exeute gameTime_Update method.
    // each time execute, will decrease _timer by 1
    void gameTime_Update(object sender, GameTimerEventArgs e)
    {
                _timer-= 1;
    }
    // on function OnNavigatedTo, after 
    timer.Start();  // this is default
    gameTime.Start();   // this what I add.
