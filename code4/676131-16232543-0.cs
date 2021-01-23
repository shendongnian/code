    class QuotaInspector : IParameterInspector
	{
		#region IParameterInspector Members
		public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
		{
		}
		public object BeforeCall(string operationName, object[] inputs)
		{
			if(ServiceSecurityContext.Current != null)
			{
				if(ServiceSecurityContext.Current.PrimaryIdentity != null
					&& ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType == "MembershipProviderValidator")
				{
					String Account = String.Empty;
					String serviceComponent = String.Empty;
					if(!String.IsNullOrEmpty(ServiceSecurityContext.Current.PrimaryIdentity.Name))
						Account = ServiceSecurityContext.Current.PrimaryIdentity.Name;
					if(OperationContext.Current != null &&
						OperationContext.Current.EndpointDispatcher != null
						&& OperationContext.Current.EndpointDispatcher.DispatchRuntime != null
						&& OperationContext.Current.EndpointDispatcher.DispatchRuntime.Type != null &&
						!String.IsNullOrEmpty(OperationContext.Current.EndpointDispatcher.DispatchRuntime.Type.Name))
						serviceComponent = ServiceSecurityContext.Current.PrimaryIdentity.Name;
					if(!String.IsNullOrEmpty(Account) && !String.IsNullOrEmpty(serviceComponent) && !string.IsNullOrEmpty(operationName))
					{
						//Apply Quota verification here
                                                //throw FaultException if quota is reached
					}
				}
			}
			return null;
		}
		#endregion
	}
