    public class PollRequestModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var body = actionContext.Request.Content.ReadAsStringAsync().Result;
            var pollRequest = JsonConvert.DeserializeObject<PollRequest>(body);
            bindingContext.Model = pollRequest;
            return true;
        }
    }
