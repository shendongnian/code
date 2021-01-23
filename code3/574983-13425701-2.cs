    //Fields
    Texture2D object;
    Vector2 object_position;
    Rectangle collisionRectangle;
    MouseState preMouse;
    bool moving = false;
    Vector2 mouseOffset;
    //initialize fields in LoadContent method
    protected override void LoadContent()
    {
        object = Content.Load<Texture2D>("nameOfYourImage");
        object_position = new Vector2((graphics.PreferredBackBufferWidth - object.Width)/2, graphics.PreferredBackBufferHeight - object.Height - 60);
        collisionRectangle = new Rectangle((int)object_position.X, (int)object_position.Y, (int)object.Width, (int)object.Height);
    }
    //add code to Update method
    
   
        
    public void MouseInput(MouseState mouse)
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
            //prevents object from going off the screen and getting lost
            if (Convert.ToInt32(object_position.X) < 0)
                object_position.X = 0;
            if (object_position.X + object.Width > graphics.PreferredBackBufferWidth)
                object_position.X = graphics.PreferredBackBufferWidth - object.Width;
            if (Convert.ToInt32(object_position.Y) < 0)
                object_position.Y = 0;
            if (object_position.Y + object.Height > graphics.PreferredBackBufferHeight)
                object_position.Y = graphics.PreferredBackBufferHeight - object.Height;
 
            //updates the collision rectangle
            collisionRectangle = new Rectangle(Postion.X, Position.Y, WIDTH, HEIGHT);
        }
        preMouse = mouse; //stores the current mouseState for use in the next Update() call
    }
