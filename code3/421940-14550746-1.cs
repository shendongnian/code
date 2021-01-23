    public class Failure : Exception
    {
      private IFailureHandling failureHandling;
      public Failure(IFailureHandling handling)
      {
        //we're injecting how the failure should be handled
        _handling = handling;
      }
      //If you need to provide additional info from 
      //the place where you catch, you can use parameter list of this method
      public void Handle() 
      {
        _handling.Perform();
      }
    }
