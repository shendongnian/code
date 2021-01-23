    public class FailureFactory
    {
      IFailureHandling _handlingOfCaseWhenSensorsAreDown,
      IFailureHandling _handlingOfCaseWhenNetworkConnectionFailed
    
      public FailureFactory(
        IFailureHandling handlingOfCaseWhenSensorsAreDown,
        IFailureHandling handlingOfCaseWhenNetworkConnectionFailed
        //etc.
        )
      {
        _handlingOfCaseWhenSensorsAreDown 
          = handlingOfCaseWhenSensorsAreDown;
        _handlingOfCaseWhenNetworkConnectionFailed 
          = handlingOfCaseWhenNetworkConnectionFailed;
        //etc.
      }
    
      public Failure CreateForCaseWhenSensorsAreDamaged()
      {
        return new Failure(_handlingOfCaseWhenSensorsAreDown);
      }
    
      public Failure CreateForCaseWhenNetworkConnectionFailed()
      {
        return new Failure(_handlingOfCaseWhenNetworkConnectionFailed);
      }
    }
