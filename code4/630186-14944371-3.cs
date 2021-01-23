    public class Player
    {
        public Point2D location;
        // facing angle in degrees
        public double facing;
        public void TurnLeft(double degrees)
        {
            facing = (facing + 360 - degrees) % 360;
        }
        public void TurnRight(double degrees)
        {
            facing = (facing + degrees) % 360;
        }
        public void MoveForward(double distance)
        {
            // calculate movement vector
            Point2D move = new Point2D(0, distance).RotateDegrees(facing);
            // add to position
            this.location.AddEquals(move);
        }
    }
