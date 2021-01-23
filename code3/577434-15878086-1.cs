    private class IgnoreNewRelicConnectionsModule : HubPipelineModule
    {
        protected override bool OnBeforeConnect(IHub hub)
        {
            NewRelic.Api.Agent.NewRelic.IgnoreTransaction();
            return base.OnBeforeConnect(hub);
        }
    }
