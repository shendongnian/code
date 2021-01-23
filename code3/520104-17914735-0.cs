    using System.Net.Http;
    using System.Threading.Tasks;
    namespace webAPI_Test
    {
    	public class MessageInterceptor : DelegatingHandler
    	{
    		protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    		{
    			// CATCH THE REQUEST BEFORE SENDING TO THE ROUTING HANDLER
    			var headers = request.ToString();
    			var body = request.Content.ReadAsStringAsync().Result;
    			var fullRequest = headers + "\n" + body;
    
    			// SETUP A CALLBACK FOR CATCHING THE RESPONSE - AFTER ROUTING HANDLER, AND AFTER CONTROLLER ACTIVITY
    			return base.SendAsync(request, cancellationToken).ContinueWith(
    						task =>
    						{
    							// GET THE COPY OF THE TASK, AND PASS TO A CUSTOM ROUTINE
    							ResponseHandler(task);
    
    							// RETURN THE ORIGINAL RESULT
    							var response = task.Result;
    							return response;
    						}
    			);
    		}
    
    		public void ResponseHandler(Task<HttpResponseMessage> task)
    		{
    			var headers = task.Result.ToString();
    			var body = task.Result.Content.ReadAsStringAsync().Result;
    
    			var fullResponse = headers + "\n" + body;
    		}
    	}
    }
