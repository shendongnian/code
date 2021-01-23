    var robot = new Robot("Fred the Robot");
    robot.PickUp(new Knife("butcher")); // output is "Fred the Robot wielded a butcher knife."
    robot.Perform(new Cut("a leg")); // output is "Fred the Robot used a butcher knife to cut a leg."
    robot.Perform(new Stab()); // output is "Fred the Robot used a butcher knife to stab."
    try { robot.Perform(new Bore()); } // InvalidOperationException: Must be holding a drill.
    catch(InvalidOperationException) {}
    robot.PutDown(); // output is "Fred the Robot put down a butcher knife."
