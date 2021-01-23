    public class ClassWithMethodsIWantToUnitTest 
    {
          public ClassWithMethodsIWantToUnitTest(ILoggerService logger)
          {}
          public void myFcn(object someArg)
          {
             ...
              logger.LogMessage("myMessage");
             ...
          }
    }
