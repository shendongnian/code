    public class ActualResourceService : RestServiceBase<ActualResource>
    {
        public override object OnGet(ActualResource request)
        {
            return new ActualResourceResponse {ResourceName = "Hi! It's the resource name."};
        }
    }
