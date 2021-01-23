    private void btnStop_Click(object sender, EventArgs e)
    { 
      if (_tcpListener != null)
      {
        _keepRunning = false;
        _listenerThread.Join();
    
        if (_tcpListener.Server.Connected)
        {
          _tcpListener.Server.Disconnect(true); 
        } _tcpListener.Stop(); 
      }
    
      labelServerStatus.Text = "Server is stopped";   
      comboBoxPorts.Enabled = true; 
      btnStart.Enabled = true; 
      btnStop.Enabled = false; 
    } 
