    private void repairClientsToolStripMenuItem_Click(object sender, EventArgs e) 
    { 
      if (machineList.Count() != 0) 
      { 
        // Start the parent task.
        var parent = Task.Factory.StartNew(
          () =>
          {
            foreach (string ws in machineList)
            {
              string capture = ws;
              // Start a new child task and attach it to the parent.
              Task.Factory.StartNew(
                () =>
                {
                  fixClient(capture);
                }, TaskCreationOptions.AttachedToParent);
            }
          }, TaskCreationOptions.LongRunning);
        // Define a continuation that happens after everything is done.
        parent.ContinueWith(
          () =>
          {
            // Code here will execute after the parent task including its children have finished.
            // You can safely update UI controls here.
          }, TaskScheduler.FromCurrentSynchronizationContext);
      } 
      else 
      { 
        MessageBox.Show("Please import data before attempting this procedure"); 
      } 
    } 
