    private void searchLogInThread(string msg, string fileName)
    {
      Task.Factory
        .StartNew(() =>
        {
          // This executes on a background thread.
    
          using (StreamReader re = File.OpenText(fileName))
          {
            string input = null;
            while ((input = re.ReadLine()) != null)
            {
              if (input.Contains(msg))
              {
                return true;
              }
            }
            return false;
          }
        })
        .ContinueWith(task =>
        {
          // This executes on the UI thread.
    
          bool result = task.Result; // Extract result from the task here.
    
          MessageBox.Show(result.ToString());
    
        }, TaskScheduler.FromCurrentSynchronizationContext);
    }
