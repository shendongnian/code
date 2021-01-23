        bool animated = false;
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            AnimateRight(gameTime);
            velocity.X = 2;
            animated = true;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            AnimateLeft(gameTime);
            velocity.X = -2;
            animated = true;
        }    
        else
        {
             velocity.X = 0;
        }  
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            if(animated == false)
            {   AnimateUp(gameTime); }
            velocity.Y = -2;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            if(animated == false)
            { AnimateDown(gameTime); }
            velocity.Y = 2;
        }
        else velocity.Y = 0;
