    class User
    {
        public Sprite sprite;
    
        public User(int width, int height, int userWidth, int userHeight)
        {
            sprite = new Sprite();
            Image UserImage = Image.FromFile("alien.jpg");
    
            X = width;
            Y = height;
            Width = userWidth;  
            Height = userHeight;
            image = UserImage;
        }
    }
