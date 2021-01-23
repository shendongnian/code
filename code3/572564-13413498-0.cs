    public T Channel {
        get {
            lock (_channelLock) {
                if (!object.Equals(_channel, default(T))) {
                    if (((ICommunicationObject)_channel).State == CommunicationState.Faulted) {
                        // channel has been faulted, we want to create a new one so clear it
                        _channel = default(T);
                    }
                }
                if (object.Equals(_channel, default(T))) {
                    // channel is null, create a new one
                    Debug.Assert(_channelFactory != null);
                    _channel = _channelFactory.CreateChannel();
                }
            }
            return _channel;
       }
