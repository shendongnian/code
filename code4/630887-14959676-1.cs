    bool myCommand = false; // declare the bool
    GamePadState oldState; // you need to know the previous state of your gamepad
    public void Update()
    {
        if (GamePad.GetState().KeyPressed == /*key*/ && oldState.KeyPressed != /*key*/)
            myCommand = !myCommand;
        oldState = GamePad.GetState();
    }
