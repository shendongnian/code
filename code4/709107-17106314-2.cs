    this.cycle.Tick += delegate(object sender, EventArgs e) {
      ThreadPool.QueueUserWorkItem(_ => {
         for (int i = 0; i < 20; i++) {
           // Doing something heavy
           System.Windows.Application.Current.Dispatcher.InvokeOrExecute(() => {
              //update the UI on the UI thread.
           });
         }
      });
    };
