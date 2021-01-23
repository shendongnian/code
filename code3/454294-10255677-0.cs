    new Action(() =>
                              {
                                  Console.WriteLine("Waiting...");
                                  Thread.Sleep(10000);
                                  Console.WriteLine("Over");
                              }).BeginInvoke(null, null);
