    private void OnPacketProgress(int packet)
    {
      var handler = evePacketProgress;
      if (handler != null)
      {
         handler(packet);
      }
    }
    
    public void startTheCapture()
    {
            // your code here
    
            while (!myStreamReader.EndOfStream)
            {
                _packet = myStreamReader.ReadLine();
                list.Add(_packet);
                OnPacketProgress(_packetsCount++);
            }
    
            // your code here
    }
