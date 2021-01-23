    class QuotaOperationBehavior : Attribute,IOperationBehavior
	{
		#region IOperationBehavior Members
		public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
		}
		public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
		{
		}
		public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
		{
			dispatchOperation.ParameterInspectors.Add(new QuotaInspector());
		}
		public void Validate(OperationDescription operationDescription)
		{
		}
		#endregion
	}
