    public class NameValueAwareModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Get the JSON data that's been posted
            var request = controllerContext.HttpContext.Request;
            var jsonStringData = new StreamReader(request.InputStream).ReadToEnd();
            // posted in format key=value&key2=value2 -> transform into namevaluecollection
            return HttpUtility.ParseQueryString(jsonStringData);
        }
    }
