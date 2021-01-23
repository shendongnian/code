      public void ProcessGetRequest<T>(WebRequest request, Action<WebResponse,T> handle, Action<Exception,T> error, T state, int delaySeconds = 0)
            {
                request.Method = "GET";
    
                Observable.FromAsyncPattern<WebResponse>(request.BeginGetResponse, request.EndGetResponse)().Delay(new TimeSpan(0, 0, delaySeconds)).ObserveOnDispatcher().SubscribeOnDispatcher().Subscribe(x=>handle(x,state),y=>error(y,state));
            }
