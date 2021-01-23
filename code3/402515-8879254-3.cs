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
      private bool CanDoAction(ActionId actionId) { ... }
      private void MarkActionDone(ActionId actionId) { ... }
    }
        
