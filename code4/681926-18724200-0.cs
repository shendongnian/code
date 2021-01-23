	public class AuthResult {
		// Note: impossible to create empty result (where both success and failure are nulls).
		// Note: impossible to create an invalid result where both success and failure exist.
		private AuthResult() {}
		public AuthResult(AuthSuccess success) {
			if (success == null) throw new ArgumentNullException("success");
			this.Success = success;
		}
		public AuthResult(AuthFailure failure) {
			if (failure == null) throw new ArgumentNullException("failure");
			this.Failure = failure;
		}
		public AuthSuccess Success { get; private set; }
		public AuthFailure Failure { get; private set; }
	}
	public class AuthSuccess {
		public string AccountId { get; set; }
	}
	public class AuthFailure {
		public UserNotFoundFailure UserNotFound { get; set; }
		public IncorrectPasswordFailure IncorrectPassword { get; set; }
	}
	public class IncorrectPasswordFailure : AuthResultBase {
		public int AttemptCount { get; set; }
	}
	public class UserNotFoundFailure : AuthResultBase {
		public string Username { get; set; }
	}
