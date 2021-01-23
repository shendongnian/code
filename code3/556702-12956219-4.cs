        public Task<Response> TaskResponse
        {
			get
			{
				var tcs = new TaskCompletionSource<Response>();
				Timeout.Elapsed += (e, a) => tcs.SetException(new TimeoutException("Timeout at " + a.SignalTime));
				
				if (_response != null) tcs.SetResult(_response);
				else ResponseHandler += tcs.SetResult; //The event passes an object of type Response (derp) which is then assigned to the _response field.
				return tcs.Task;
			}
        }
