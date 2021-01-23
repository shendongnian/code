    public class SearchBinder : DefaultModelBinder {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
           PropertyDescriptor propertyDescriptor) {
            if (propertyDescriptor.Name == "Group" &&
                bindingContext.ValueProvider.GetValue("Group.Name") != null &&
                bindingContext.ValueProvider.GetValue("Group.Name").AttemptedValue == "") {
                ModelState modelState = new ModelState { Value = bindingContext.ValueProvider.GetValue("Group.Name") };
                modelState.Errors.Add("Please create a new group or choose an existing one.");
                bindingContext.ModelState.Add("Group.Name", modelState);
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
    // Register custom model binders in Application_Start()
    ModelBinders.Binders.Add(typeof(SearchViewModel), new SearchBinder());
