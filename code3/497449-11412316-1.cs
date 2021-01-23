        action.BeginInvoke(param, (ar)=>
                {
                    IAsyncSubscriber subscriber = (IAsyncSubscriber)ar.AsyncState;
                    T1 returnValue = action.EndInvoke(ar);
                    subscriber.Callback(returnValue);
                }, subscriber);
