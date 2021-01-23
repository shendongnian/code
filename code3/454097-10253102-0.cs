    entA: Console.Write("a?");   
    try { a = Convert.ToInt32(Console.ReadLine()); }
    catch 
    { /*If a=0, the equation isn't quadratic*/
      Console.WriteLine("Invalid input"); 
      goto entA;             
    } 
