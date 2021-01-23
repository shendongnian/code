    public class DedicatedThread
    {
      private BlockingCollection<Action> actions = new BlockingCollection<Action>();
    
      public DedicatedThread()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              Action action = actions.Take();
              action();
            }
          });
      }
    
      public void SubmitAction(Action action)
      {
        actions.Add(action);
      }
    }
