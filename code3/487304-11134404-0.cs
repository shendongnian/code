        private void SetLock(bool lock)
        {
            LoadButton.Enabled = !lock;
            MonthEndDateEdit.Enabled = !lock;
            BankIssuerListEdit.Enabled = !lock;
            _updateMessageTaskInProgress = lock;
        }
        private void PerformUpdate()
        {
            if (!_updateMessageTaskInProgress)
            {
                SetLock(true);
                Task updateMessages = Task.Factory.StartNew(() =>
                {
                    ExpensiveMethod();
                });
                // Task runs when updateMessages completes without exception.  Runs on UI thread.
                Task updateComplete = updateMessages.ContinueWith(update =>
                {
                    DoSuccessfulStuff();
                    SetLock(false);
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
                // Task runs when updateMessages completes with exception.  Runs on UI thread.
                Task updateFailed = updateMessages.ContinueWith(task =>
                {
                    DoFailureStuff();
                    SetLock(false);
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
