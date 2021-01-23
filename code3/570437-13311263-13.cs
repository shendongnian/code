    public class ActualResourceService : Service
    {
        public object Get(ActualResource request)
        {
            return new ActualResourceResponse {
               ResourceName = "Hi! It's the resource name." };
        }
    }
