    // Handles all incoming requests.
    public class GenericProcessor
    {
      public delegate void ActionEventHandler(object sender, ActionEventArgs e);
      public event ActionEventHandler ActionEvent;
      public ProcessAction(int actionValue)
      {
        if (this.ActionEvent != null)
        {
          this.ActionEvent(this, new ActionEventArgs(actionValue));
        }
      }
    }
    // Definition of values for request
    // Extend as needed
    public class ActionEventArgs : EventArgs
    {
      public ActionEventArgs(int actionValue)
      {
        this.ActionValue = actionValue;
      }
      public virtual int ActionValue { get; private set; }
    }
