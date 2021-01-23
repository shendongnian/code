    public string FileSource;
    public string FileName;
    public ThreadPriority Priority;
    
    public ThreadInfo(string File, ThreadPriority priority)
    {
       FileSource = File;
       FileName = Path.GetFileNameWithoutExtension(File);
       Priority = priority;
    }
    
    static void Main()
    {
       ThreadInfo ti = null;
       try
       {
          ti = new ThreadInfo(FileName, ThreadPriority.Normal);
          ThreadPool.QueueUserWorkItem(ThreadImageProcess.doWork, ti);
       }
       catch (Exception error)
       {
          MyEventLog.WriteEntry("Error creating Thread Pool: "+ error.StackTrace, EventLogEntryType.Error, (int)ImageProcess.MyEventID.ProcessFile, (int)ImageProcess.MyErrorCategory.Information, null);
       }
       finally
       {
          if (ti != null)
              ti = null;
       }
    }
    public static void doWork(object sender)
    {
      string FileName = "";
      try
      {
         Thread.CurrentThread.Priority = (sender as ThreadInfo).Priority;
         FileName = (sender as ThreadInfo).FileSource;
      }
      catch (Exception error)
      {
         //send some message
      }
    }
