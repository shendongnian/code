    static class ControlExtensions
    {
      public static void InvokeOrExecute(this Control control, Action action)
      {
         if (control.InvokeRequired)
         {
            control.Invoke(action);
         }
         else
         {
            action();
         }
      }
    }
