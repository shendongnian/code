    public class OperationResult
    {
        public OperationResult(OperationState state, string message = String.Empty)
        {
            State = state;
            Message = message;
        }
     
        public OperationState State { get; private set; }
        public string Message { get; private set; }
        // property for "result"
        // property for "invisiblecolumns
        public enum OperationState
        {
            Update,
            Success,
            Error
        }
    }
