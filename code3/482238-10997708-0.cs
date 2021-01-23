     public static class myExtension
    {
    
       public static bool AllConsecutives(this IEnumerable<int> targetList)
       {
          bool result = false;
    
          if ((targetList != null) && (targetList.Any ()))
          {
             var ordered = targetList.OrderBy (l => l);
    
             int first = ordered.First ();
    
             result = ordered.All (item => item == first++);
    
          }
    
          return result;
    
       }
    
    }
    
    // tested with
    
    void Main()
    {
     Console.WriteLine ( (new List<int>() {2, 3, 4, 5, 6}).AllConsecutives() ); // true
     Console.WriteLine ( (new List<int>() {3, 7, 4, 5, 6}).AllConsecutives() ); // true //as it is not sensitive to list order
     Console.WriteLine ( (new List<int>() {2, 3, 4, 7, 6}).AllConsecutives() ); // false //as the five is missing
    }
