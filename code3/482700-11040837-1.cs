    Observable.Interval(TimeSpan.FromMilliseconds(150))
                          .SampleSubscribe((v, ct) =>
                          {   
                              //cbeck for cancellation, do work
                              for (int i = 0; i < 10 && !ct.IsCancellationRequested; i++)
                                  Thread.Sleep(100);
    
                              Console.WriteLine(v);
                          });
