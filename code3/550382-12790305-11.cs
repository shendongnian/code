    // Handles a specific (or multiple) requests
    public class SomeActionProcessor
    {
      public void HandleActionEvent(object sender, ActionEventArgs e)
      {
        if (e.ActionValue == 1)
        {
          this.HandleAction();
        }
      }
      private void HandleAction()
      {
      }
    }
