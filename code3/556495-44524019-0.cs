    static bool isRunning = false;
    public void RunThread(){
        if (!isRunning)
        {
        Thread t = new Thread(()=> { go(); isRunning = true;});
        t.IsBackground = true;
        t.Name = "myThread";
        t.Start();
        }
        else
        {
          System.Diagnostics.Debug.WriteLine("myThread is already Running.");
        }   
    }
    public void go()
    {
        //My work goes here
    }
