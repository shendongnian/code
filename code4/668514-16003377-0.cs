    CancellationTokenSource cts = new CancellationTokenSource();
    Task tsk = Task.Factory.StartNew(() =>
                                          {
                                              Measurement measurement = new Measurement();
                                              measurement.Execute(cts.Token);
                                          }, cts.Token);
