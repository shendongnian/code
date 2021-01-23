    private bool _mouseIsIntersecting;
    public void Update(...)
    {
        rectangle = new Rectangle(...);
        Rectangle mouseRectangle = new Rectangle(...);
        if(mouseRectangle.Intersects(rectangle))
        {
            // Handle click and size stuff
            // Only play the sound if mouse was not previously intersecting
            if (!_mouseIsIntersecting)
                soundEffect.Play();
            _mouseIsIntersecting = true;
        }
        else
        {
            _mouseIsIntersecting = false;
            // Handle other stuff
        }
    }
