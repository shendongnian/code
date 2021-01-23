    using System.Diagnostics;
    
    ProcessThreadCollection currentThreads = Process.GetCurrentProcess().Threads;
    foreach (var thread in currentThreads)
    {
       thread.Interupt(); // If thread is waiting, stop waiting
       
       // or
       thread.Abort(); // Terminate thread immediately 
      // or
       thread.IsBackGround = true;
    }
