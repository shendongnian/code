    public void Update(MouseState mouse)
    {
        if (collsionRectangle.Contains(mouse.X, mouse.Y) && //mouse is over the object
            //the user is clicking the left mousebutton
            mouse.LeftButton == ButtonState.Pressed && 
            //in the previous Update() call the left mousebutton was released, 
            //meaning the user has just clicked the object
            preMouse.LeftButton == ButtonState.Released)
        {
            moving = true;
            //stores what the objects position should be offset by so it doesn't
            //snap to the mouse's position every time you click on it
            mouseOffset = new Vector2(Position.X - mouse.X, Position.Y - mouse.Y);
        }
        if (moving)
        {
            //if the player stops holding down the mousebutton i.e stops moving the object
            if (mouse.LeftButton == ButtonState.Released)  
                moving = false;
            //modifies the position
            Position.X = mouse.X + mouseOffset.X;
            Position.Y = mouse.Y + mouseOffset.Y;
            //updates the collision rectangle
            collisionRectangle = new Rectangle(Postion.X, Position.Y, WIDTH, HEIGHT);
        }
        preMouse = mouse; //stores the current mouseState for use in the next Update() call
    }
