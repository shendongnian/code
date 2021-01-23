    public class Ball
    {
        public int speedX { get; private set; }
        public int speedY { get; private set; }
        public int positionX { get; private set; }
        public int positionY { get; private set; }
	
        public Ball(int speedX, int speedY, int positionX, int positionY)
        {
    	    this.speedX = speedX;
            this.speedY = speedY;
    	    this.positionX = positionX;
            this.positionY = positionY;
        }
        public int setSpeedX(int newSpeed)
        {
            speedX = newSpeed;
        }
        //Add any other setters you need.
    } 
