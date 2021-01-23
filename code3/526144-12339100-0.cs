    abstract class ActionHelper {
    
        protected abstract Delegate CreateActionImpl();
    
        // A subclass with a static type parameter
        private class ActionHelper<T> : ActionHelper {
            protected override Delegate CreateActionImpl() {
                // create an Action<T> and downcast
                return new Action<T>(obj => Console.WriteLine("Called = " + (object)obj));
            }
        }
    
        public static Delegate CreateAction(Type type) {
            // create the type-specific type of the helper
            var helperType = typeof(ActionHelper<>).MakeGenericType(type);
            // create an instance of the helper
            // and upcast to base class
            var helper = (ActionHelper)Activator.CreateInstance(helperType);
            // call base method
            return helper.CreateActionImpl();
        }
    }
    
    // Usage
    // Note: The "var" is always "Delegate"
    var @delegate = ActionHelper.CreateAction(anyTypeAtRuntime);
