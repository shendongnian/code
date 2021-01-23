	public class Ball
	{
		public int SpeedX { get; set; }
		public int SpeedY { get; set; }
		public int PositionX { get; set; }
		public int PositionY { get; set; }
		public Ball(int speedX, int speedY, int positionX, int positionY)
		{
			this.SpeedX = speedX;
			this.SpeedY = speedY;
			this.PositionX = positionX;
			this.PositionY = positionY;
		}
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			Ball ball1 = new Ball(1,1,1,1);
			Ball ball2 = new Ball(2,2,2,2);
			Ball ball3 = new Ball(3,3,3,3);
			ball3.SpeedX = ball1.SpeedX + ball2.SpeedX;
		}
	}
