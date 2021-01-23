    for (int ii = 0; ii <= 5; ii++)
                {
                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += (s, args) =>
                        {
                            args.Result = (int)args.Argument;
                            Thread.Sleep(100);
                        };
                    backgroundWorker.RunWorkerCompleted += (s, args) =>
                    {
                        int value = (int)args.Result;
                        Rectangle rectr = (Rectangle)FindName("rect" + value);
                        rectr.Fill = Brushes.Black;
                    };
                    backgroundWorker.RunWorkerAsync(ii);
                }
