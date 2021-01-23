    var someDisposableObject = someMethodCallOrCallToNew();
    try
    {
      //Do Stuff
    }
    finally
    {
      if(someDisposableObject != null)
        ((IDisposable)someDisposableObject).Dispose();
    }
