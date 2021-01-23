               // Repeat every 2 seconds.
            IObservable<long> observable = Observable.Interval(TimeSpan.FromSeconds(2));
            // Token for cancelation
            CancellationTokenSource source = new CancellationTokenSource();
            // Create task to execute.
            Action action = (() => Console.WriteLine("Action started at: {0}", DateTime.Now));
            Action resumeAction = (() => Console.WriteLine("Second action started at {0}", DateTime.Now));
            // Subscribe the obserable to the task on execution.
            observable.Subscribe(x => { Task task = new Task(action); task.Start();
                                          task.ContinueWith(c => resumeAction());
            }, source.Token);
