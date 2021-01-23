    public User(int width, int height, int userWidth, int userHeight)
    {
        Sprite sprite = new Sprite();
        Image UserImage = Image.FromFile("alien.jpg");
        sprite.X = width;
        sprite.Y = height;
        sprite.Width = userWidth;  
        sprite.Height = userHeight;
        sprite.image = UserImage;
    }
