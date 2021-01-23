    public class LoggingOperationBehavior : IOperationBehavior
    {
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new LoggingOperationInvoker(dispatchOperation.Invoker, operationDescription, dispatchOperation);
        }
        // (TODO stub implementations)
    }
