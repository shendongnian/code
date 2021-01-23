        public class RobotNavigationService
        {
            public RobotNavigationService(Func<string, IRobot> robotFactory)
            {
                var killer = robotFactory("Maximilian");
                var standard = robotFactory("");
            }
        }
