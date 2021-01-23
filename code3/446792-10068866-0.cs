        public void ProcessGetRequest(WebRequest request, Action<WebResponse,object> handle, Action<Exception,object> error, object state, int delaySeconds = 0)
        {
            request.Method = "GET";
            Observable.FromAsyncPattern<WebResponse>(request.BeginGetResponse, request.EndGetResponse)().Delay(new TimeSpan(0, 0, delaySeconds)).ObserveOnDispatcher().SubscribeOnDispatcher().Subscribe(x=>handle(x,state),y=>error(y,state));
        }
