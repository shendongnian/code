    static void Main(string[] args)
        {
            window = new RenderWindow(new VideoMode(256,512), "Car Game");
            window.Closed += new EventHandler(OnClose);
            // Note this
            // window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            Sprite bg = new Sprite(new Texture("road.png"));
            car = new Sprite(new Texture("car.png"));
            car.Position = new Vector2f(window.Size.X / 2, window.Size.Y - 96);
            while (window.IsOpen())
            {
                window.DispatchEvents();
                CheckInputs(); // and this !
                window.Clear();
                window.Draw(bg);
                window.Draw(car);
                window.Display();
            }
        }
    
    void CheckInputs()
    {
        if(Keyboard.isKeyPressed(Keyboard.key.A))
        {
            if(car.Position.X < 0)
                car.Position.X = 0
            else if(car.Position.X > 0)
                car.Position.X -= 8; // shortcut for 'car.Position.X = car.Position.X - 8'
        }
        else if(Keyboard.isKeyPressed(Keyboard.key.D))
        {
            // etc
        }
    }
