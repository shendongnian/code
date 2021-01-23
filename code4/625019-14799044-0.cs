    public class RobotBase
    {
        protected int data;
        
        // Reference to the world
        protected World _world;
        public RobotBase(World world)
        {
            _world = world;
        }
        public void ChangeData()
        {
            data = 10;
        }
    }
