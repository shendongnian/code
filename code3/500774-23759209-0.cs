        public class NullValueModelBinder : DefaultModelBinder, IModelBinder {
            
          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
             
             object model = base.BindModel(controllerContext, bindingContext);
    
             if (model is INullValueModelBindable && (model as INullValueModelBindable).IsNull()){
                 return null;
             }
    
             return model;
          }
        }
        
        public interface INullValueModelBindable {
            bool IsNull();
        }
