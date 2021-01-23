    public sealed class SendPendingEmailTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            // send your e-mails here
            deferral.Complete();
        }
    }
