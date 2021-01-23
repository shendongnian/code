    var task = Task.Factory.StartNew(() =>
                                         {
                                             pic.Image = Properties.Resources.NEXT;
                                         },
                                     CancellationToken.None,
                                     TaskCreationOptions.None,
                                     ui);
    task.ContinueWith(t => Thread.Sleep(1000), TaskScheduler.Default)
        .ContinueWith(t =>
                          {
                              pic.Image = Properties.Resources.Prev;
                          }, ui);
