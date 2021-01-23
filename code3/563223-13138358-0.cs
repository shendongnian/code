        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    	public class AuthenticateUserAttribute : Attribute, IOperationBehavior {
    		#region Implementation of IOperationBehavior
    
    		public void Validate(OperationDescription operationDescription) {
    		}
    
    		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation) {
    			// Manual injection
    			var userService = NinjectWebCommon.Kernel.Get<IUserService>();
    
    			// Assign the custom authentication invoker, passing in the original operation invoker
    			dispatchOperation.Invoker = new UserAuthenticationInvoker(dispatchOperation.Invoker, operationDescription.SyncMethod.ReturnType, userService);
    		}
    
    		public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) {
    			throw new NotImplementedException("This behaviour cannot be applied to a server operation.");
    		}
    
    		public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters) {
    		}
    
    		#endregion
    	}
