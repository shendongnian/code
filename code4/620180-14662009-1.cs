      BackgroundWorker bw = new BackgroundWorker();
      // You will delete all items here!
      cboPlan.Items.Clear();
      bw.DoWork += new DoWorkEventHandler(bw_Add);
      bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_AddComplete);
      // plan is String.Empty because there are no items in the combobox!
      plan = cboPlan.Text;
      Busy.IsBusy = true;
      Busy.BusyContent = "Sending Request.";
      // You will start populating combobox asynchronously here 
      bw.RunWorkerAsync();
