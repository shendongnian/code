            var task1 = Task.Factory.StartNew(DoSomeWork);
            var task2 = task1.ContinueWith(result =>
                {
                    if (DoSomeMoreWork())
                    {
                        Task.Factory.StartNew(DoFinalWork, TaskCreationOptions.AttachedToParent);
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
