    public class MyTrace 
    {
         [Conditional("TRACE")]
         public static void Trace(string message)
         {
              //trace code goes here
         }
         [Conditional("DEBUG")] 
         public static void Debug(string message)
         {
              //Debug code goes here
         }
    }
