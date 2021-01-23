    private void RegisterMessages() 
    {
        Messenger.Default.Register<LaunchShowReservoirMessage>(this, ReservoirReceived);
    }
    
    private void ReservoirReceived(LaunchShowReservoirMessage msg) {
        this.LocalReservoir = msg.Reservoir;
    }
    
    public Reservoir LocalReservoir { get... set... } ...
