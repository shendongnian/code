         private void DoWork()
                {
                    var ctx = TaskScheduler.FromCurrentSynchronizationContext();
        
                    RunningTask = Task.Factory
                        .StartNew(DownloadAndInstallFiles, CancelTokenSource.Token)
                        .ContinueWith(_ => ShowResultForm(), CancelTokenSource.Token, TaskContinuationOptions.NotOnFaulted, ctx);
                }
        
                private void ShowResultForm()
                {
                    UpdateResultForm = new Forms.UpdateResult();
                    // Some other code
                    UpdateResultForm.Show();
                }
