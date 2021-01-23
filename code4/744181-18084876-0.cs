    public class FancyRobot : BaseRobot
    {
       public FancyRobot : base(7, 8, 9) 
       { // calls the 2nd constructor on the base class
          Console.WriteLine("Created a fancy robot with defaults");
       }
    }
