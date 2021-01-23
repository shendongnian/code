     obj a = new obj(); // Assuming obj : IDisposable
     try 
     {
        // Your code here
     }
     finally
     {
        if (a != null)
        { 
           a.Dispose();
        }
     }
