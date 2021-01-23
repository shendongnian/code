     catch ({System.DivideByZeroException ex )
     {
        Console.WriteLine("Ops. I cannot divide by zero." );
     }
     catch ({System.Exception ex )
     {
        Console.WriteLine("There was an error during calculations: {0}", ex.Message );
     }
     
