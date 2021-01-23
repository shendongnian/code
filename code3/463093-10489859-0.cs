    public class ParameterTracerOperationBehavior : IOperationBehavior
    {
        // ...
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var originalInvoker = dispatchOperation.Invoker;
            var operationName = operationDescription.Name;
            var newInvoker = new ParameterTracerInvoker(originalInvoker, operationName);
            dispatchOperation.Invoker = newInvoker;
        }
    }
    
    public class ParameterTracerInvoker
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string operationName;
        public ParameterTracerInvoker(IOperationInvoker oldInvoker, string operationName)
            : base(oldInvoker)
        {
            this.operationName = operationName;
        }
        // ...
    }
