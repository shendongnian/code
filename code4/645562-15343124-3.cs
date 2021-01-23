    private delegate void ExecuteActionHandler(Action action);
    public static void ExecuteOnUiThread(this Form form, Action action)
    {
      if (form.InvokeRequired) { // we are not on UI thread
        // Invoke or BeginInvoke, depending on what you need
        form.Invoke(new ExecuteActionHandler(ExecuteOnUiThread), action);
      }
      else { // we are on UI thread so just execute the action
        action();
      }
    }
