    mouseStateCurrent = Mouse.GetState();
 
    if (mouseStateCurrent.LeftButton == ButtonState.Pressed)
    {
        if (mouseStatePrevious.LeftButton != ButtonState.Pressed)
        {
            AddProjectile(player.positionPlayer);
            
            mouseStatePrevious = mouseStateCurrent; //<-- This line
        }
    }
    //<-- Here
