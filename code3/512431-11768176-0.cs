    private void sendSetData(TcpClient c)
    {
        IEnumerable<AbstractTrafficElement> list;
        lock (completedATEQueueSynched)
        {
            list = MainForm.completedATEQueue.ToList();  // take a snapshot
        }
    
        NetworkStream clientStream = c.GetStream();
        foreach (AbstractTrafficElement ate in list)
        {
           binaryF.Serialize(clientStream, ate);
        }    
    }
