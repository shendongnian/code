    ThreadPool.QueueUserWorkItem(_ => {
                    foreach (int item in Enumerable.Range(1,50)) {
                      Thread.Sleep(500);//simulate some calculations here
                      int item1 = item;
                      Deployment.Current.Dispatcher.BeginInvoke(() => {
                          stackPanel.Children.Add(new TextBlock(){Text = "Text "+item1});
                      });
                    }
                });
