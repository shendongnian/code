    public void RemoveDates()
            {
                var checkDatesTask= new Task(
                    () =>
                        {
                            while (!_cancelationTokenSource.IsCancellationRequested)
                            {
                                //TODO: check and delete elements here
    
                                _cancelationTokenSource.Token.WaitHandle.WaitOne(
                                    TimeSpan.FromSeconds(
                                       5));
                            }
                        },
                    _cancelationTokenSource.Token,
                    TaskCreationOptions.LongRunning);
                checkDatesTask.Start();
            }
