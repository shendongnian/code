    public class Robot : RobotBase
    {
        public Robot(World world) : base(world)
        {}
        public void RobotChangesData()
        {
            //Change data in base
            data = 20;
            // Change data in world, the object is passed by reference, no need for further "ref" declarations
            _world.Terminate();
        }
    }
