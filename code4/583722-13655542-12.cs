    public class LoggingOperationInvoker : IOperationInvoker
    {
        IOperationInvoker _baseInvoker;
        string _operationName;
        public LoggingOperationInvoker(IOperationInvoker baseInvoker, DispatchOperation operation)
        {
            _baseInvoker = baseInvoker;
            _operationName = operation.Name;
        }
        // (TODO stub implementations)
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            MyInfrastructure.LogStart(_operationName, inputs);
            try
            {
                return _baseInvoker.Invoke(instance, inputs, out outputs);
            }
            catch (Exception ex)
            {
                MyInfrastructure.LogError(_operationName, inputs, ex);
                return null;
            }
            MyInfrastructure.LogEnd("Add", parameters);
        }
    }
