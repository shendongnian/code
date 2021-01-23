    class Foo
    {
       Stopwatch watch = new Stopwatch();
    
       public void RunProcess(Process process)
       {
          process.Exited += new EventHandler(ProcessExit);
    
          process.Start();
          watch.Start();
       }
    
       public void ProcessExit(object sender, EventArgs e)
       {
          watch.Stop();
       }
    }
