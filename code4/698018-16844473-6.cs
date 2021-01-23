    BluetoothListener l = new BluetoothListener(LOCAL_MAC, BluetoothService.SerialPort);
    l.Start(10);
    l.BeginAcceptBluetoothClient(new AsyncCallback(AcceptConnection), l);
    void AcceptConnection(IAsyncResult result){
        if (result.IsCompleted){
            BluetoothClient remoteDevice = ((BluetoothListener)result.AsyncState).EndAcceptBluetoothClient(result);    
        }    
    }
