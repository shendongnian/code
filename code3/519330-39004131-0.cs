      public Task<IResult> GetLongWindedTaskResult(){
              var tcs = new TaskCompletionSource<IResult>();
                try
                {
                   tcs.SetResult(ResultOFSomeFunction());
                }
                catch (Exception exp)
                {
                    tcs.SetException(exp);
                }
                return tcs.Task;
    }
