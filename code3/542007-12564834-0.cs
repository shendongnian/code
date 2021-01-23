    public void FunA () // accessed from thread 1 (when user click a button)
    {
      lock(myObject)
        {
           myObject = null;
           // do some stuff
           myObject = new MyObject ( someNewValues );
        }
    }
