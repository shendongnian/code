	public static class ExtensionMethods
	{
		public static WebResponse GetResponse(this WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			WebResponse response = null;
			request.BeginGetResponse ((IAsyncResult ar) => {
				response = request.EndGetResponse(ar);
				evt.Set();
			}, null);
			evt.WaitOne ();
			return response as WebResponse;
		}
		public static Stream GetRequestStream(this WebRequest request){
			ManualResetEvent evt = new ManualResetEvent (false);
			Stream requestStream = null;
			request.BeginGetRequestStream ((IAsyncResult ar) => {
				requestStream = request.EndGetRequestStream(ar);
				evt.Set();
			}, null);
			evt.WaitOne ();
			return requestStream;
		}
	}
