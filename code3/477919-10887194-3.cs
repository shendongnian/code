    public class DictionaryModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the posted JSON
            var request = controllerContext.HttpContext.Request;
            var jsonStringData = new StreamReader(request.InputStream).ReadToEnd();
            //use newtonsoft.json to deserialise the json into IDictionary
            return JsonConvert.DeserializeObject<IDictionary<string,string>>(jsonStringData);
        }
    }
