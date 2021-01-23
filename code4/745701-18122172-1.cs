    public void WriteToConsole(BaseRobot robot)
    {
       Console.WriteLine("Robot has home at {0} It is facing {1} and is currently at {2}",
                         robot.Home, robot.Orientation, robot.Position);
    }
