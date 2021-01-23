    interface IRobot
    {
         int Fuel { get; }
    }
    robot2 = robot as FighterBot;
    Fuel = robot2.Fuel;
    // robot2 is STILL stored as IRobot, so the interface allowed 
    // to communicate with this object will be restricted by 
    // IRobot, no matter what object you put in (as long as it implements IRobot)
    robot2.Fuel = 10; // evidently, won't compile.
