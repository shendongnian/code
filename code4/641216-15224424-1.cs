    protected T WrappedChannel {
        get {
            lock (_channelLock) {
                if (!object.Equals(_wrappedChannel, default(T))) {
                    var state = ((ICommunicationObject)_wrappedChannel).State;
                    if (state == CommunicationState.Faulted) {
                        // channel has been faulted, we want to create a new one so clear it
                        _wrappedChannel = default(T);
                    }
                }
                if (object.Equals(_wrappedChannel, default(T))) {
                    _wrappedChannel = _factory.CreateChannel();
                }
            }
            return _wrappedChannel;
        }
    }
    public TResult Invoke(Func<T, TResult> func) {
        try {
            return action(WrappedChannel);
        }
        catch (FaultException ex) {
            throw;
        }
        catch (CommunicationException ex) {
            // maybe retry works
            return action(WrappedChannel);
        }
    }
    protected virtual void Dispose(bool disposing) {
        if (!disposing || 
            object.Equals(_wrappedChannel, default(T))) 
            return;
        var channel = _wrappedChannel as ICommunicationObject;
        _wrappedChannel = default(T);
        try {
            channel.Close();
        }
        catch (CommunicationException) {
            channel.Abort();
        }
        catch (TimeoutException) {
            channel.Abort();
        }
    }
    public void Dispose() {
        Dispose(true);
    } 
