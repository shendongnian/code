    public class OperationStatus
    {
      public bool IsSuccess { set;get;}
      public string ErrorMessage { set;get;}
      public string ErrorCode { set;get;}
      public string InnerException { set;get;}
    }
    public class BaseEntity
    {
      public OperationStatus OperationStatus {set;get;}
      public BaseEntity()
      {
          if(OperationStatus==null)
             OperationStatus=new OperationStatus();
      } 
    }
