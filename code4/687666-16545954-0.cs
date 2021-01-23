    public class MyActionSelector : ApiControllerActionSelector
    {
        public override HttpActionDescriptor SelectAction(
                                    HttpControllerContext context)
        {
            HttpMessageContent requestContent = new HttpMessageContent(
                                                               context.Request);
            var json = requestContent.HttpRequestMessage.Content
                                    .ReadAsStringAsync().Result;
            string type = (string)JObject.Parse(json)["type"];
    
            var actionMethod = context.ControllerDescriptor.ControllerType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "Create" + type);
    
            if (actionMethod != null)
            {
                return new ReflectedHttpActionDescriptor(
                                   context.ControllerDescriptor, actionMethod);
            }
    
            return base.SelectAction(context);
        }
    }
