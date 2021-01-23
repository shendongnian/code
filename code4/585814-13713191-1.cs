    public sealed class Class1
        {
            public IAsyncActionWithProgress<Result> testAsync()
            {
                return AsyncInfo.Run<Result>((token, result) =>
                    Task.Run<Result>(()=>
                        {
                            // do this asynchronously ...
                            return new Result();
                        }
    
                    ));
            }
        }
    
        public sealed class Result { ... }
        }
