    if(newKeyState.IsKeyDown(Keys.W))
    {
        position.Y -= vel;
    }
    else if(newKeyState.IsKeyDown(Keys.S))
    {
        position.Y += vel;
    }
    // etc.
