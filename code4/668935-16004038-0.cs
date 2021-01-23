    public class MyModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request.Params;
            var keys =
                from key in request.Keys.Cast<string>()
                where request[key] == "on"
                select key;
            var onValues = new List<int>();
            foreach (var key in keys)
            {
                int value;
                if (int.TryParse(key, out value))
                {
                    onValues.Add(value);
                }
            }
            return onValues.ToArray();
        }
    }
