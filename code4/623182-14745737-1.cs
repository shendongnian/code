    private void btnStop_Click(object sender, EventArgs e)
    { 
      if (_tcpListener != null)
      {
        _keepRunning = false;
    
        if (_tcpListener.Server.Connected)
        {
          _tcpListener.Server.Disconnect(true); 
          _tcpListener.Stop(); 
          _listenerThread.Join();
        }
      }
    
      labelServerStatus.Text = "Server is stopped";   
      comboBoxPorts.Enabled = true; 
      btnStart.Enabled = true; 
      btnStop.Enabled = false; 
    } 
