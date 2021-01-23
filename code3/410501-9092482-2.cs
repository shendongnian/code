    Subscribers.Values.ToList().ForEach(delegate(IServiceCallback callback)
                {
                    if (((ICommunicationObject) callback).State == CommunicationState.Opened)
                    {
                       //send callback
                    }
                    else
                    {
                       // remove subscriber because channel its not open anymore
                    }
                 });
