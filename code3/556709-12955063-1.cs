    public static class ActionExtensions
    {
        public static void RunWithMargueProgress(this Action action)
        {           
            var progressForm = new ProgressForm();
            progressForm.Show();
            Task.Factory.StartNew(action)
                .ContinueWith(t =>
                                  {
                                      progressForm.Close();
                                      progressForm.Dispose();
                                  }, TaskScheduler.FromCurrentSynchronizationContext());            
        }
    }
