      var task = Task.Factory.StartNew<List<NewTwitterStatus>>(
                                () => GetTweets(securityKeys),  
                                TaskCreationOptions.LongRunning
                            )
            .ConstinueWith(tsk => EndTweets(tsk) );
        void EndTweets(Task<List<string>> tsk)
        {
            var strings = tsk.Result;
            // now you have your result, Dispatchar Invoke it to the Main thread
        }
