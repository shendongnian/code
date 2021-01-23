    public class HttpWebRequestResult : IResult
    	{
    		public HttpWebRequest HttpWebRequest { get; set; }
    		public string Result { get; set; }
    
    		public HttpWebRequestResult(string url)
    		{
    			HttpWebRequest = (HttpWebRequest) HttpWebRequest.Create(url);
    			
    		}
    
    		public void Execute (ActionExecutionContext context)
    		{
    			HttpWebRequest.BeginGetResponse (Callback, HttpWebRequest);
    		}
    
    		public void Callback (IAsyncResult asyncResult)
    		{
    			var httpWebRequest = (HttpWebRequest)asyncResult.AsyncState;
    			var httpWebResponse = (HttpWebResponse) httpWebRequest.EndGetResponse(asyncResult);
    
    			using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
    				Result = reader.ReadToEnd();
    
    			Completed (this, new ResultCompletionEventArgs ());
    		}
    
    		public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    	}
