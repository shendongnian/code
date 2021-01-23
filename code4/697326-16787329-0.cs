    class Program
    {
        static void Main(string[] args)
        {
            Ball b = new Ball(1,2,3,4);
            //b.setPositionY() = b.setSpeedY() + b.setSpeedY();
           b.setPositionY(b.setSpeedX() + b.setSpeedY());            
            
        }
    }
    public class Ball
    {
        public int speedX { get; set; }
        public int speedY { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public Ball(int speedX, int speedY, int positionX, int positionY)
        {
            this.speedX = speedX;
            this.speedY = speedY;
            this.positionX = positionX;
            this.positionY = positionY;
        }
        public int setSpeedX()
        {
            //speedX = newSpeedX;
            return 10;
        }
        public int setSpeedY()
        {
            //speedY = newSpeedY;
            return 20;
        }
        public int setPositionX()
        {
            //positionX = newPositionX;
            return 1;
        }
        public void setPositionY(int newPositionY)
        {
            positionY = newPositionY;
            
        }
    }
