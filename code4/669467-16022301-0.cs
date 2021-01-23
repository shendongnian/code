    public string GetByIds(int[] ids)
        {
            return "multiple";
        }
    ------------------------
    config.ParameterBindingRules.Insert(0, typeof(int[]), (paramDesc) => new SampleParameterBinding(paramDesc));
    -------------------------
    public class SampleParameterBinding : HttpParameterBinding
    {
        public SampleParameterBinding(HttpParameterDescriptor desc)
            : base(desc)
        {
        }
        public override bool WillReadBody
        {
            get
            {
                return false;
            }
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpRequestMessage currentRequest = actionContext.Request;
            NameValueCollection nvc = currentRequest.RequestUri.ParseQueryString();
            //TODO: ERROR CHECKS
            int[] ids = nvc["ids"].Split(',').Select(str => Int32.Parse(str)).ToArray();
            // Set the binding result here
            SetValue(actionContext, ids);
            // now, we can return a completed task with no result
            TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
            tcs.SetResult(default(AsyncVoid));
            return tcs.Task;
        }
        private struct AsyncVoid
        {
        }
    }
