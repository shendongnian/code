        // in SwitchConnection class
        public List<string> GetAllConnections(List<string> connectionChain) {
        
        // to start at any given object just pass in a null reference
        if (connectionChain == null) { connectionChain = new List<string>; }
        
        connectionChain.Add(this.Name);
        
        if (this.RemoteSwitch !=null) {
           RemoteSwitch.GetAllConnections(connectionChain);
        }
    
        return connectionChain;
    }
