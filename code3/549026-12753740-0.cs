        public void WakeUpInstanceAsync(Foo opportunity, bool isHistorical, Action<WakeupObj> callback)
        {
            this.ImplementAsyncMethod(
                asyncCallback => _funnelClient.BeginWakeUpInstance(opportunity, isHistorical, asyncCallback, null),
                asyncResult => _funnelClient.EndWakeUpInstance(asyncResult),
                callback);
        }
        public void ImplementAsyncMethod<T>(Action<AsyncCallback> begin, Func<IAsyncResult, T> end, Action<T> callback)
        {
            if (IsOpen())
            {
                AsyncCallback asyncCallback = (e) =>
                {
                    _currentDispatcher.BeginInvoke(() =>
                    {
                        try
                        {
                            callback(end(e));
                        }
                        catch (CommunicationException ex1)
                        {
                            // Notify someone via eventaggregator?
                            callback(default(T));
                        }
                    });
                };
                begin(asyncCallback);
            }
        }
