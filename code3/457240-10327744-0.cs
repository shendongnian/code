    enum GameState
    {
        Playing,
        Message
    }
    GameState _gameState = GameState.Playing;
    String _messageToDisplay = "";
    int _score = 0;
    protected override void Update(GameTime gameTime)
    {
        if(_gameState == GameState.Playing)
        {
            if(CollideGoalArea())
            {
                if(CollideGoalkeeper())
                {
                    _messageToDisplay = "Goalie defends the goal!";
                    _gameState = GameState.Message;
                }
                else
                {
                    _messageToDisplay = "GOAL!";
                    score++;
                    _gameState = GameState.Message;
                }
            }
            else
            {
                _messageToDisplay = "You missed the goal.";
                _gameState = GameState.Message;
            }
        }
        else if(_gameState == GameState.Message)
        {
            if(Mouse.GetState().RightButton == ButtonState.Pressed) // right click to continue playing
                 _gameState = GameState.Playing;
            //you should also reset your ball position here
        }
    }
