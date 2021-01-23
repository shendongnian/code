      public void ResetState()
      {
        lock(syncObj)
        {
          state = false;
          stateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
      }  
    
    }
