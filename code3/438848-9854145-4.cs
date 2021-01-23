      public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            input = new InputHandler(this);
            Components.Add(input);
            Services.AddService(typeof(IInputHandler), input);
            camera = new Camera(this);
            Components.Add(camera);
            
            input.UpdateOrder = 0;
            camera.UpdateOrder = 1;
            // this component alows Asyncroniously save/load game.
            Components.Add(new GamerServicesComponent(this));
    #if DEBUG
            fps = new FPS(this);
            Components.Add(fps);
            fps.UpdateOrder = 1;
            camera.UpdateOrder = 2;
    #endif
        }
