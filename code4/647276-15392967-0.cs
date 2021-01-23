    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR.Hubs;
    
    public class MyHubPipelineModule : HubPipelineModule
    {
        protected override Func<IHubIncomingInvokerContext, Task<object>> BuildIncoming(Func<IHubIncomingInvokerContext, Task<object>> invoke)
        {
            return async context =>
            {
                try
                {
                    // This is responsible for invoking every server-side Hub method in your SignalR app.
                    return await invoke(context); 
                }
                catch (Exception e)
                {
                    // If a Hub method throws, have it return the error message instead.
                    return e.Message;
                }
            };
        }
    }
