    public class AuthenticationHubPipelineModule : HubPipelineModule
    {
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            var id = MyUserManager.Instance.CurrentUserID.ToString();
            context.Hub.Groups.Add(context.Hub.Context.ConnectionId, id);
            return base.OnBeforeIncoming(context);
        }
    }
