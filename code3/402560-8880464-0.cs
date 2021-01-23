    public class PasswordEmptyOrNullException : Exception
	{
		public PasswordEmptyOrNullException(string message)
			: base(message)
		{
		}
	}
	public class OldPasswordNotFoundException : Exception
	{
		public OldPasswordNotFoundException(string message)
			: base(message)
		{
		}
	}
