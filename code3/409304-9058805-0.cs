     public class MyTime
     {
     [Require]
     [Range(0, 12, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
     public int Hours { get; set; }
     [Require]
     [Range(0, 60, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
     public int Minutes { get; set; }
     }
     
