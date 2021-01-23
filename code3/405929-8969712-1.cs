    [System.Diagnostics.DebuggerStepThroughAttribute()]
    public partial class MyServiceClient : ClientBase<IMyService>, IMyService
    {
        public MyServiceClient ()
        {
        }
    
        public void Execute(EnumdParam action);
        {
            return base.Channel.Execute(action);
        }
    }
