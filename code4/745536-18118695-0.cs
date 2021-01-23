    [ServiceContractAttribute]
    public interface ISampleService
    {
        [OperationContractAttribute]
        string SampleMethod();
        
        [OperationContractAttribute(AsyncPattern = true)]
        IAsyncResult BeginSampleMethod(AsyncCallback callback, object asyncState);
        
        string EndSampleMethod(IAsyncResult result);
    }
    public class SampleService : ISampleService
    {
        // the async method needs to be private so that WCF doesn't try to
        // understand its return type of Task<string>
        private async Task<string> SampleMethodAsync()
        {
            // perform your async operation here
        }
        
        public string SampleMethod()
        {
            return this.SampleMethodAsync().Result;
        }
        
        public IAsyncResult BeginSampleMethod(AsyncCallback callback, object asyncState)
        {
            var task = this.SampleMethodAsync();
            if (callback != null)
            {
                task.ContinueWith(_ => callback(task));
            }
            
            return task;
        }
        
        public string EndSampleMethod(IAsyncResult result)
        {
            return ((Task<string>)result).Result;
        }
    }
