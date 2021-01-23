    public class WcfTracingOperationBehavior : IOperationBehavior
      {
    
    	#region Implementation of IOperationBehavior
    
    	public void Validate(OperationDescription operationDescription)
    	{
    
    	}
    
    	public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    	{
    		dispatchOperation.Invoker = new WcfTracingOperationInvoker(dispatchOperation.Invoker, operationDescription);
    	}
    
    	public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    	{
    
    	}
    
    	public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    	{
    
    	}
    
    	#endregion
    
      }
    
