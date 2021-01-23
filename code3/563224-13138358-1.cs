	public class UserAuthenticationInvoker : IOperationInvoker {
		/// <summary>
		/// 	The original operation invoker.
		/// </summary>
		private readonly IOperationInvoker _originalInvoker;
		private readonly Type _responseType;
		private readonly IUserService _userService;
		public SupplierAuthenticationInvoker(IOperationInvoker originalInvoker, Type responseType, IUserService userService) {
			_originalInvoker = originalInvoker;
			_responseType = responseType;
			_userService = userService;
		}
		#region Implementation of IOperationInvoker {
		public object[] AllocateInputs() {
			return _originalInvoker.AllocateInputs();
		}
		public object Invoke(object instance, object[] inputs, out object[] outputs) {
			// Validate base objects request
			if(!(inputs[0] is BaseOperationRequest)) throw new ArgumentException("The request object must inherit from BaseOperationRequest in order for user authentication to take place.");
			dynamic response = Activator.CreateInstance(_responseType);
			if(!(response is BaseOperationResponse)) throw new InvalidOperationException("The response object must inherit from BaseOperationResponsein order for user authentication to take place.");
			var req = (BaseOperationRequest)inputs[0];
			// Authenticate the user
			var authResult = _userService.AuthenticateUser(new AuthenticateUserRequest {
				Token = req.Token,
				Password = req.Password
			});
			if(!authResult.Success) {
				// Authentication failed, return reflected response object.
				outputs = new object[0];
				// Set response headers
				response.Success = false;
				response.ErrorCode = ServiceErrors.AuthErrorInvalidTokenOrPassword;
				return response;
			}
			// Authentication success, set the user and call the original method
			dynamic modifiedInput = inputs;
			modifiedInput[0].User = authResult.User;
			var invoked = _originalInvoker.Invoke(instance, modifiedInput, out outputs);
			return invoked;
		}
		public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state) {
			throw new NotImplementedException("The operation cannot be invoked asynchronously.");
		}
		public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result) {
			throw new NotImplementedException("The operation cannot be invoked asynchronously.");
		}
		public bool IsSynchronous {
			get { return true; }
		}
		#endregion
	}
