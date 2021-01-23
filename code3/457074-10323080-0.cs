    public void BuildAll()
    {
        StoreNodes(() => { Method2(); });
    }
    
    public void StoreNodes(Action getNodesCompleteAction)
    {    
        DataServiceClient client = new DataServiceClient();
        
        client.GetNodesForCoreCompleted += (sender, e) => {
          // your handler code
    
          // call Method2() Action wrapper
          getNodesCompleteAction();
        }
    
        client.GetNodesForCoreAsync();
    }
