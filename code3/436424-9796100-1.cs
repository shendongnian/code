    Vector2 destPos;
    Vector2 stepAnm; //Needs to be set when destPos is updated
    float duration; //Could be dependent on distance or not
    protected override void Update(GameTime gameTime)
    {
        float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        float moveAmount = elapsedSeconds / duration;
        Vector2 movement = stepAnm * moveAmount;
        //This should fix going too far
        if (movement.DistanceSquared() > (destPos - curPos).LengthSquared())
        {
            curPos = destPos;
        }
        else
        {
            curPos += stepAnm * moveAmount; //+= or -= depending on how you calculate stepAnm
        }
    }
