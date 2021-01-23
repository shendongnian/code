    public class MyModule : HubPipelineModule
    {
    	protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
    	{
    		return context.Connection.ShouldSend();
    	}
    }
