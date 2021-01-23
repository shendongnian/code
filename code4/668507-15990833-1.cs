    class Invader : Sprite
    {
        readonly float distanceFromCenterHorizontal;
        public Invader(float distanceFromCenterHorizontal)
        {
            this.distanceFromCenterHorizontal= distanceFromCenterHorizontal;
        }
        public void UpdatePosition(Point center)
        {
            this.Position.X = center.X + distanceFromCenterHorizontal;
            this.Position.Y = center.Y;
        }
    }
    // global variables:
    Point center = ....
    bool moveLeft = false;
    void createInvaders()
    {
        int invaderWidth = 20; // whatever your value is
        float columnCenter = ((float) columnMax) / 2 * invaderWidth;
        for(var column = 0; column < columnMax ; column++)
        {
            float invaderX = (column * invaderWidth);
            
            float distanceFromCenterHorizontal = invaderX - columnCenter;
            for(var row = 0; row < rowMax; row ++)
            {
                Invader invader = new Invader(distanceFromCenterHorizontal);
                invader.Position.Y = row * invaderHeight // Needs adjustment here!
            }
        }
    }
    void update()
    {
        if(center.X == screenWidth) moveLeft = true;
        else if(center.X <= 0) moveLeft = false;
        
        center.X += moveLeft? -step : step;
        
        foreach(var invader in invaders) invader.UpdatePosition(center);
    }
