    public class FooModelBinder: IModelBinder
    {
        #region IModelBinder Members
    
        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext) {
    
            IUnvalidatedValueProvider provider = (IUnvalidatedValueProvider)bindingContext.ValueProvider;
            return new Foo {
                Bar = provider.GetValue("Bar", true).AttemptedValue,
                Banana= provider.GetValue("Banana", true).AttemptedValue
            };
    
        }
    
        #endregion
    }
