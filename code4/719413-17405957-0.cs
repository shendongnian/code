    public void PasswdThread(int i)
    {
    handles[i] = new ManualResetEvent(false);
    
     Thread.Sleep(1000);
     Random r=new Random();
     int n=r.Next(10);
     if (n==5)
     {
         num=r.Next(1000);
     }
     handles[i].Set();
    }
