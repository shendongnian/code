    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        if (bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
        {
            RouteValueDictionary baseModel = (bindingContext.Model as RouteValueDictionary) ?? (base.BindModel(controllerContext, bindingContext) as RouteValueDictionary);
            if (baseModel != null)
            {    // start off with a direct copy of the bound model            
                var returnModel = new RouteValueDictionary();
                baseModel.ForEach(x => returnModel[x.Key] = item.Value);
                
                // Sometimes the DefaultModelBinder turns the RouteValueDictionary.Values property into a collection of single-item arrays. This resets them to the correct values.
                foreach (var key in baseModel.Keys)
                {
                    returnModel[key] = GetValue(bindingContext, key); // GetValue method body below                        
                }
                return returnModel;
            }
        }
        return null;
    }
    private object GetValue(ModelBindingContext context, string key)
    {
        var name = String.Format("{0}[{1}]", String.IsNullOrEmpty(context.ModelName) ? String.Empty : context.ModelName, key);
        var attemptedResult = context.ValueProvider.GetValue(name);
        
        if (attemptedResult != null && attemptedResult.AttemptedValue != null)
        {
            return attemptedResult.AttemptedValue;        
        }
        
        return null;
    }
