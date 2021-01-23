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
public class WcfTracingOperationInvoker : IOperationInvoker
{
	private readonly IOperationInvoker _originalInvoker;
	private string ServiceFullName { get; set; }
	private string ServiceName { get; set; }
	private string MethodName { get; set; }
	public WcfTracingOperationInvoker(IOperationInvoker originalInvoker, OperationDescription operationDescription)
	{
		_originalInvoker = originalInvoker;
		var declaringType = operationDescription.SyncMethod.DeclaringType;
		if (declaringType != null)
		{
			ServiceFullName = declaringType.FullName;
			ServiceName = declaringType.Name;
		}
		MethodName = operationDescription.SyncMethod.Name;
	}
	#region Implementation of IOperationInvoker
	public object[] AllocateInputs()
	{
		SetMethodInfo();
		return _originalInvoker.AllocateInputs();
	}
	public object Invoke(object instance, object[] inputs, out object[] outputs)
	{
		var result = _originalInvoker.Invoke(instance, inputs, out outputs);
		return result;
	}
	public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
	{
		return _originalInvoker.InvokeBegin(instance, inputs, callback, state);
	}
	public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
	{
		return _originalInvoker.InvokeEnd(instance, out outputs, result);
	}
	public bool IsSynchronous
	{
		get { return _originalInvoker.IsSynchronous; }
	}
	#endregion
	private void SetMethodInfo()
	{
		// The WcfContext is some my stuff.
		var wcfTraceActivity = WcfContext<WcfTraceActivity>.Current;
		wcfTraceActivity.ServiceName = ServiceName;
		wcfTraceActivity.ServiceFullName = ServiceFullName;
		wcfTraceActivity.MethodName = MethodName;
	}
}
