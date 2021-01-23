    //variables needed
    public bool follow = true;
    public Vector2D startpoint;
    //puts the startpoint value equal
    //to the inital location of the player
    public Player()
    {
        startpoint.X = rectangle.X;
        startpoint.Y = rectangle.Y;
    }
    //if any of the collision tests fail
    if(collision occurs)
    {
        collision();
    }
    //else update startpoint to new valid location
    else 
    {
        startpoint.X = rectangle.X;
        startpoint.Y = rectangle.Y;
        follow = true;
    }
    if(follow == true)
    {
        //movement commands occur
    }
    else
    {
        follow = true;
    }
    //if a condition fails set player
    //too last valid location
    public void collision()
    {
        rectangle.X = startpoint.X;
        rectangle.Y = startpoint.Y;
        follow = false;
    }
