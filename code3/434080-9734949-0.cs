        public Game1()
        {
           graphics = new GraphicsDeviceManager(this);
    
           graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
      
           // Frame rate is 60 fps
           TargetElapsedTime = TimeSpan.FromTicks(166667);
        }
