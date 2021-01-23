    public class RestartJob : IJob
    {        
        public RestartJob()
        {
        }
    
        public virtual void Execute(IJobExecutionContext context)
        {
            var @event = context.JobDetail.JobData["event-handler"];
            @event?.Invoke(YourEventParameters); 
        }
    }
