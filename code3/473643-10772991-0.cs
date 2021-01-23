        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs) {
            const int n = 15;
            var tasks = new Task<int>[n];
            for (int i = 0; i < n; i++) {
                tasks[i] = Task.Factory.StartNew(
                    () => {
                        Thread.Sleep(500);
                        return 100;
                    });
            }
            Task.Factory.ContinueWhenAll(
                tasks,
                ts => { text.Text = string.Format("Sum: {0}", ts.Sum(task => task.Result)); },
                CancellationToken.None,
                TaskContinuationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext());
        }
