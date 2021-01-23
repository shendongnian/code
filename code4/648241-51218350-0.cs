    System.AggregateException: One or more errors occurred. ---> System.InvalidOperationException: Couldn't get value!
       at async Task<double> ValuesController.GetValue2()
       at async Task<double> ValuesController.GetValue()
       --- End of inner exception stack trace ---
       at void System.Threading.Tasks.Task.ThrowIfExceptional(bool includeTaskCanceledExceptions)
       at TResult System.Threading.Tasks.Task<TResult>.GetResultCore(bool waitCompletionNotification)
       at TResult System.Threading.Tasks.Task<TResult>.get_Result()
       at double ValuesController.GetValueAction()
       at void Program.Main(string[] args)
    ---> (Inner Exception #0) System.InvalidOperationException: Couldn't get value!
       at async Task<double> ValuesController.GetValue2()
       at async Task<double> ValuesController.GetValue()<---
