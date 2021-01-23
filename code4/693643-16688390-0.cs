    class StartGame
    {
        void MyMethod()
        {
            Ball myBall = new Ball(0, 1, 2, 3);
            int speedX = myBall.speedX;       // == 0
            int speedY = myBall.speedY;       // == 1
            int positionX = myBall.positionX; // == 2
            int positionY = myBall.positionY; // == 3
        }
    }
