        public class TestParameterInspector : IParameterInspector
    {
        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            OperationContext.Current.Extensions.Add(new ContextSessionExtension() {SomeData = "testme"} );
        }
    }
        public class ContextSessionExtension : IExtension<OperationContext>
    {
        public void Attach(OperationContext owner)
        {
            
        }
        public void Detach(OperationContext owner)
        {
            
        }
        public string SomeData { get; set; }
    }
