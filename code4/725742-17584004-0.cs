    public static int currentScreen = 0; // Any screen can change this variable when needed
    List<Screenobject> myscreens = new List<Screenobject>(); // Populate this with screens
    // OR
    menuscreen = new menuScreen();
    otherscreen = new otherScreen();
    // ...
    protected override void Update(GameTime gameTime)
    {
          myscreens[currentScreen].Update(gameTime);
          // OR
          switch (currentScreen)
          {
              case 1:
                   menuscreen.Update(gameTime); break;
              // ...
          }
          base.Update(gameTime);
    }
