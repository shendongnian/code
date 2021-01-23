    INotifyCallback callbackObject = new NotifyCallbackImpl(); //your concrete callback class
    var channelFactory = new DuplexChannelFactory<IMyDataServce>(callbackObject); //pick your favourite constructor!
    IMyDataService channel = channelFactory.CreateChannel();
    try {
        var guid = channel.Authenticate(....);
        //... use guid...
    } finally {
        try {
            channel.Close();
        } catch (Exception) {
            channel.Abort();
        }
    }
