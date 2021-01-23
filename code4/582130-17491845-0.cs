    #if !NETFX_CORE 
      using (MyGame game = new MyGame()) 
      { 
          game.Run();
      } 
    #endif 
    #if NETFX_CORE 
      var factory = newMonoGame.Framework.GameFrameworkViewSource<MyGame>();
      Windows.ApplicationModel.Core.CoreApplication.Run(factory); 
    #endif } 
