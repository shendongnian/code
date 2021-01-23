    static object lockObject = new Object();
    static bool inProgress = false;
    
    static void MyProcess()
    {
      if(inProgress) return;
    
      lock(lockObject)
      {
        try{
          inProgress = true;
          // critical code here
        }
        finally
        {
          inProgress = false;
        }
      }
    }
