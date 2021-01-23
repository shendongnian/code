    public class Ball
    {
        public Color Color { get; set; }
        public Point Location { get; set; }
        public Vector2D Velocity { get; set; }
    }
    var balls = new List<Ball>(20);
    for(int i = 0; i < 20; i++)
    {
        balls.Add(new Ball { Location = new Point(5, 5) });
    }
