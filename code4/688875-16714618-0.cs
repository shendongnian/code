    private void Update(GameTime gameTime)
    {
        var frameHasChanges = DetectChanges(); //This method you need to figure out yourself
        if (!frameHasChanges)
        {
            SuppressDraw();
            base.Update(gameTime);
            return;
        }
        
        //Do the rest of normal Update
    
    }
