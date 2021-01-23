    public class EmailModelBinder : IModelBinder
    {
        public bool BindModel(
            HttpActionContext actionContext, 
            ModelBindingContext bindingContext)
        {
            string body = actionContext.Request.Content
                           .ReadAsStringAsync().Result;
            Dictionary<string, string> values = 
                JsonConvert.DeserializeObject<Dictionary<string, string>>(body);
            var entity = Activator.CreateInstance(
                typeof(IEmail).Assembly.FullName, 
                values.FirstOrDefault(x => x.Key == "ObjectType").Value
                ).Unwrap();
            JsonConvert.PopulateObject(body, entity);
            bindingContext.Model = (IEmail)entity;
            return true;
        }
    }
