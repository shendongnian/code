    public void Connect() {
       if(!_connected) {
          ExecuteConnect();
          _connected = true;
       }
    }
    public void Disconnect() { 
       if(_connected) {
          ExecuteDisconnect();
          _connected = false;
       }
     }
     protected abstract void ExecuteConnect();
     protected abstract void ExecuteDisconnect();
