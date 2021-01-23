    public void BallMovement()
    {
        int speedInt = Convert.Int32(speed);
        if (movingUp) { ballRect.Y -= speedInt; }
        if (!movingUp) {  ballRect.Y += speedInt; }
        if (movingLeft) {  ballRect.X -= speedInt; }
        if (!movingLeft) {  ballRect.X += speedInt; }
        if (ballPosition.Y < 85)
        {
            movingUp = false;
        }
        if (ballPosition.Y >= 480)
        {
            movingUp = true;
        }
        ....
