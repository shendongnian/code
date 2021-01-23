    public InputHandler(...)
    {
        // Your initialization code here
        
        this.Game.Services.AddService(typeof(IInputHandler), this);
    }
