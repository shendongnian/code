	internal sealed class MyFirstCustomBehavior : Attribute, System.ServiceModel.Description.IOperationBehavior
	{
		#region IOperationBehavior Members
		public void AddBindingParameters(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
			//no special behaviour
		}
		public void ApplyClientBehavior(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
		{
			throw new NotImplementedException();
		}
		public void ApplyDispatchBehavior(System.ServiceModel.Description.OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
		{
			dispatchOperation.ParameterInspectors.Add(new MyFirstCustomParameterInspector());
		}
		public void Validate(System.ServiceModel.Description.OperationDescription operationDescription)
		{
			//no special behaviour
		}
		#endregion
	}
