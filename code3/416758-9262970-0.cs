    class Robot : IDisposable
    {
        static private int IdNext = 0;
        static private int IdOfDestroy = -1;
        public int RobotID
        {
            get;
            private set;
        }
        public Robot()
        {
            if(IdOfDestroy == -1)
            {
                this.RobotID = Robot.IdNext;
                Robot.IdNext++;
            }
            else
            {
                this.RobotID = Robot.IdOfDestroy;
            }
        }
        public void Dispose()
        {
            Robot.IdOfDestroy = this.RobotID;
        }
    }
