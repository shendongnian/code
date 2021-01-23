    StringBuilder db = new StringBuilder();
    sb.AppendFormat("Robot has home at <{0},{1}> ", robot.Home.X, robot.Home.Y);
    sb.AppendFormat("It is facing {0} ", robot.Orientation);
    sb.AppendFormat("and is currently at <{0},{1}>", robot.Position.X, robot.Position.Y);
    Console.WriteLine(sb.ToString());
