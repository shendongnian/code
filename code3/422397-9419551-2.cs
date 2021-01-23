    class MyRequest: IRequest {
        // other interface implementation details omitted
        public void SetProfiles(Profile p) {
          if(HasUglyPicture(p)) {
             MyLogger.LogError(String.Format(
                     "User {0} update attempted with ugly picture", p.UserName)
             throw new Exception("Profile update failed due to ugly picture!");
         }
     }
     class MyLogger : ILogger {
          // other logger details omitted
          public void LogError(string errorMsg) {
              // here's where you get the method name 
              // http://www.csharp-examples.net/reflection-calling-method-name/              
              StackTrace stackTrace = new StackTrace();
              MyLogOutputStream.Write(stackTrace.GetFrame(1).GetMethod().Name);
              MyLogOutputStream.WriteLine(errorMsg);
          } 
     }
