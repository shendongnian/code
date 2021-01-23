    public class LetterA : ContentControl, IGameEntity
    {
        private int speed = 0;
        public LetterA()
        {
            var letterImage = new Image()
            {
                Height = 45,
                Width = 45,
                Source = new BitmapImage(new Uri("images/a.png", UriKind.RelativeOrAbsolute))
            };
            Content = letterImage;
            var random = new Random();
            Canvas.SetLeft(this, -20); 
            Canvas.SetTop(this, random.Next(250, 850));
            speed = random.Next(1, 5);
        }   
        public void Update(Canvas c)
        {
            Canvas.SetLeft(this, Canvas.GetLeft(this) - speed);
            if (Canvas.GetLeft(this) < 100)
                c.Children.Remove(this);
        }
    }
