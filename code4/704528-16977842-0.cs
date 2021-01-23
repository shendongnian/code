    public class PersonModelBinder : IModelBinder {
    public object BindModel(ControllerContext controllerContext,
    ModelBindingContext bindingContext) {
    
    // see if there is an existing model to update and create one if not
    Person model = (Person)bindingContext.Model ??
    (Person)DependencyResolver.Current.GetService(typeof(Person));
    // find out if the value provider has the required prefix
    bool hasPrefix = bindingContext.ValueProvider
    .ContainsPrefix(bindingContext.ModelName);
    string searchPrefix = (hasPrefix) ? bindingContext.ModelName + "." : "";
    // populate the fields of the model object
    model.PersonId = int.Parse(GetValue(bindingContext, searchPrefix, "PersonId"));
    model.FirstName = GetValue(bindingContext, searchPrefix, "FirstName");
    model.LastName = GetValue(bindingContext, searchPrefix, "LastName");
    model.BirthDate = DateTime.Parse(GetValue(bindingContext,
    searchPrefix, "BirthDate"));
    model.IsApproved = GetCheckedValue(bindingContext, searchPrefix, "IsApproved");
    model.Role = (Role)Enum.Parse(typeof(Role), GetValue(bindingContext,
    searchPrefix, "Role"));
    return model;
    }
    private string GetValue(ModelBindingContext context, string prefix, string key) {
    ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
    return vpr == null ? null : vpr.AttemptedValue;
    }
    private bool GetCheckedValue(ModelBindingContext context, string prefix, string key) {
    bool result = false;
    ValueProviderResult vpr = context.ValueProvider.GetValue(prefix + key);
    if (vpr != null) {
    result = (bool)vpr.ConvertTo(typeof(bool));
    }
    return result;
    }
    }
