    // To pause the game for x number of frames, set pauseDelay = to x
    int pauseDelay;
    
    public void Update() {
         if (pauseDelay > 0) {
             --pauseDelay;
             
             physics.Update();
             ai.Update();
         }
         input.Update();
         sound.Update();
    }
