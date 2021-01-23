    public class Ball
    {
        public int Size { get; private set; }
        public string Name { get; private set; }
        public Ball(string name , int size)
        {
            Name = name;
            Size = size;
        }
  
        public Ball(Ball firstBall, Ball secondBall)
        {
            Name = firstBallName + ", " + secondBall.Name;
            Size = firstBall.Size + secondBall.Size;
        }
    } 
