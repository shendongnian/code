     private void SearchBTDevices()
        {
          Thread thread = new Thread(new ThreadStart(delegate{
            List<BluetoothDevice> list = new List<BluetoothDevice>();
            this.Invoke(new MethodInvoker(() => this.discoverableDevices.Clear()); //DiscoverableDevices is binding to the form
            list.foreach(x => this.Discoverable.Add(x));
            
            var connectedDevices = list.Where(x => x.HasAuthenticated).ToList());  
            this.Invoke(new MethodInvoker(() => {
                ConnectedSEMDevices.Clear()
                ConnectedSEMDevices.AddRange(connectedDevices)));}
            }
          }));
      thread.Start();
    }
