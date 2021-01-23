    class Robot {
        static int nextId;
        public int RobotId {get; private set;}
        Robot() {
            RobotId = Interlocked.Increment(ref nextId);
        }
    }
