    class User:Sprite
    {
        public User(int width, int height, int userWidth, int userHeight)
        {
            Image UserImage = Image.FromFile("alien.jpg");
    
            X = width;
            Y = height;
            Width = userWidth;  
            Height = userHeight;
            image = UserImage;
        }
    }
