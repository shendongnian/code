    public class BaseResponse
    {
      public virtual string ErrorMessage { get;}
    }
    
    
    public class Person:BaseResponse
    {
      .....
      public override string ErrorMessage {get { return "Err msg related to Person";}}
    }
    public class Phone:BaseResponse
    {
      ......
      public override string ErrorMessage {get { return "Err msg related to Phone";}}
    }
