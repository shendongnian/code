    public class IgnoreNewRelicModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            NewRelic.Api.Agent.NewRelic.IgnoreTransaction();
            return base.OnBeforeIncoming(context);
        }
    }
