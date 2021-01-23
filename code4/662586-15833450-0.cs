    public void Move(float x, float y, Camera2D Camera)
    {
        Position.X += x;
        if ((Position.X < Camera.Min.X))
           Position.X = Camera.Min.X;
        if ((Position.X + Width) > Camera.Max.X)
           Position.X = Camera.Max.X - Width;
        float centerX = Position.X + (Width / 2);
        if (centerX > (Camera.Min.X + (ScreenDimension.X / 2)))
        {
            if (centerX < (Camera.Max.X - (ScreenDimension.X / 2)))
            {
                Camera.Move(-x, 0);
            }
            else
            {
                Camera.SetPosition(-(Camera.Max.X - ScreenDimension.X), Camera.Position.Y);
            }
        }
        else
        {
            Camera.SetPosition(Camera.Min.X, Camera.Position.Y);
        }
        // Removed Y because of code length
    }
