    public class Node : IComparable
    {
       Node Parent{get;set;}
       Node LChild {get;set;}
       Node RChild {get;set;}
       Node C {get;set;}
    
       public int CompareTo(object o)
       {
          // Now you passed C in your object, do stuff ...
       }
    }
