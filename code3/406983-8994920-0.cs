    public class Program
    {
       private static object _memberField;
    
       private static void MemberMethod()
       {
         // not here:
         // private static object _insideMethod; // <- will not work
       }
    }
