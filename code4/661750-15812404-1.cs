    public class InheritanceBinder : DefaultModelBinder
        {
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var modelType = bindingContext.ModelType;
                object model = modelType.Assembly.CreateInstance(modelType.FullName);
    
                var inheritedtypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => model.GetType().IsAssignableFrom(t)).ToList();
                HttpRequestBase req = controllerContext.HttpContext.Request;
                var keys = req.Form.Keys.Cast<string>().Where(q => q != "__RequestVerificationToken").ToList();
    
    
    
                List<KeyValuePair<Type, int>> matches = new List<KeyValuePair<Type,int>>();
    
                inheritedtypes.ForEach(t => {
                    int p_matches = 0;
                    
                    Array.ForEach(t.GetProperties(), item =>
                    {
                        if (keys.Any(key => item.Name == key))
                            p_matches++;
                    });
    
                    matches.Add(new KeyValuePair<Type, int>(t, p_matches));
                });
    
    
    
    
                var bestmatches = matches.Where(q => q.Value == matches.Max(s => s.Value));
                if (!bestmatches.Any())
                    throw new TargetInvocationException("Could not determine model to bind based on the form values provided", null);
    
                var usematch = bestmatches.First().Key;
    
                object bindObj = Activator.CreateInstance(usematch);
    
    
    
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => bindObj, usematch);
    
                return base.BindModel(controllerContext, bindingContext);
            }
    
            
        }
