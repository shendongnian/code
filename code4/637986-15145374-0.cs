    public class Example
    {
       public enum ArrivalStatus { Late=-1, OnTime=0, Early=1 };
       public static void Main()
       {
          ArrivalStatus status1 = new ArrivalStatus();
          Console.WriteLine("Arrival Status: {0} ({0:D})", status1);
       }
    }
    // The example displays the following output: 
    //       Arrival Status: OnTime (0)
