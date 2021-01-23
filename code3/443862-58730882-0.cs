    public class CommaSeparatedToArrayBinder<T> : IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                Type type = typeof(T);
                if (type.IsPrimitive || type == typeof(Decimal) || type == typeof(String) || type == typeof(float))
                {
                    ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                    if (val == null) return false;
    
                    string key = val.RawValue as string;
                    if (key == null) { bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type"); return false; }
    
                    string[] values = key.Split(',');
                    IEnumerable<T> result = this.ConvertToDesiredList(values).ToArray();
                    bindingContext.Model = result;
                    return true;
                }
    
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Only primitive, decimal, string and float data types are allowed...");
                return false;
            }
    
            private IEnumerable<T> ConvertToDesiredArray(string[] values)
            {
                foreach (string value in values)
                {
                    var val = (T)Convert.ChangeType(value, typeof(T));
                    yield return val;
                }
            }
        }
