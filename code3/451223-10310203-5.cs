    public class ResourceUtilisation
    {
      private Mutex _mut=new Mutex("mutex control",true);
      //.. does stuff
      private static void UseResource()
      {
        // Wait until it is safe to enter.
        _mut.WaitOne();
        //Go get dataabse and add some rows
        DoStuff();
        // Release the Mutex.
        _mut.ReleaseMutex();
      }
    }
