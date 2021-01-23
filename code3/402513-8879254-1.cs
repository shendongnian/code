    public class WorldManager
    {
      public bool TryDoAction(ActionId actionId, Action action)
      {
        if (!this.CanDoAction(actionId)) return false;
        try
        {
          action();
          return true;
        }
        finally
        {
          this.MarkActionDone(actionId);
        }
      }
        
