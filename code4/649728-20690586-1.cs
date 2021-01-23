    	class Program 
	{
		static void Main() 
		{
			var decryptedValue = HttpContext.Current.Request.DecryptQueryStringParam("myParam");
		}
	}
    public static class HttpRequestExtensions 
	{
		public static string DecryptQueryStringParam(this HttpRequest extendee, string name)
		{
			// do stuff to decrypt
			return DecryptMethodStub(extendee.QueryString[name]);
		}
		
		private string DecryptMethodStub(string queryString)
		{
			return "something decrypted the string";
		}
	}
