    public class Keyword
    {
         public delegate void Do();
    }
    
    //Area of Execution
    {
       //...
       Keyword k = new Keyword();
       k.Do = delegate() 
       {
           Console.Writeln("Anonymous Inner function assigned to a callback function i.e a Delegate!");  
       };
    }
