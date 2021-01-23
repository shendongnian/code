    public interface ILuw : ILuwEvent, IDisposable
      {
 
       IBosCurrentState CurrentState{ get; set; }
       OperationStatus Commit();
       }
