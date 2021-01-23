    // Decorated calls
    TraceDecorator.Aspect(() => StaticLogic.SuccessfulCall());
    TraceDecorator.Aspect(() => StaticLogic.ExceptionCall());
    TraceDecorator.Aspect(() => StaticLogic.SuccessfulCallWithReturn(42));
    TraceDecorator.Aspect(() => StaticLogic.ExceptionCallWithReturn(42));
    // Decorator itself
    public static class TraceDecorator {
        public static T Aspect<T>(Func<T> func) {
            try { return func(); }
            catch(Exception ex) {
                LogException(ex);
                return default(T);
            }    
        }
        
        public static void Aspect(Action func) {
            try { func(); }
            catch(Exception ex) { LogException(ex); }    
        }
        
        private static void LogException(Exception ex) {
            Console.WriteLine("Traced by TraceDecorator: {0}", ex);
        }
    }
