    using System;
    using System.Threading;
    namespace Utility.Async{
        static public class TPContext{
            static public T Call<T>(Func<T> handler) {
                var currentContext = SynchronizationContext.Current;
                SynchronizationContext.SetSynchronizationContext(null);
                try {
                    return handler();
                }finally {
                    SynchronizationContext.SetSynchronizationContext(currentContext);
                }
            } 
        }
    }
