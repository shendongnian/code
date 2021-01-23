    class XYZ
    {
      Object syncObj = new Object();
      ...
      public void RunInPlayBettingControl(int SystemPK,string betfairLogon, string betfairPassword, string systemName, int RacePK)
      {
        lock(this.syncObj)
        { }
        ...
        case 2:
          // race is in play but not over our marker yet so go back in after a short wait
          lock(this.syncObj)
          {
              Thread.Sleep(1000);
          }
          ...
        }
      }
    }
