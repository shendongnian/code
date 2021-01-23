    //this will move an object to the left
    Vector2 speed = new Vector2(-10, 0);
    public void Update(GameTime theGameTime)
    {
        //this will add the speed of the sprite to its position
        //making it move
        Position[0] += speed;
        Position[1] += speed;
        Position[2] += speed;
        base.Update(theGameTime, mSpeed, mDirection);
    }
