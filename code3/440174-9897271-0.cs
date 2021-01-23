    private KeyboardState now; // suggest rename to something like mCurrentKeyboardState
    private KeyboardState old; // suggest rename to something like mLastKeyboardState
    ...
    public void Update(GameTime gameTime)
    {
       old = now;
       now = Keyboard.GetState();
       ...
