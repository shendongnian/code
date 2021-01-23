     public class C : IDisposable  
     {
        ...
    
        void Dispose()
        {
          timer.Elapsed -= timer_elapsed;
        }
     }
