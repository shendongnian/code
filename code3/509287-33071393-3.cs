    public class AddressModelBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            var posted = actionContext.Request.Content.ReadAsStringAsync().Result;
            AddressDTO address = JsonConvert.DeserializeObject<AddressDTO>(posted);
            if (address != null)
            {
                // moar val here
                bindingContext.Model = address;
                return true;
            }
            return false;
        }
    }
