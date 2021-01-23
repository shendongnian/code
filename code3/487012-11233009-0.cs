      private static EventDelegate<EventInfoBase> DelegateWrapper<T>(Delegate @delegate) where T : EventInfoBase
      {
         return (o =>
            {
               var t = @delegate as EventDelegate<T>;
               var args = o as T;
               if (t != null && o != null)
               {
                  t(args);
               }
            }
         );
      }
      private static readonly MethodInfo s_eventMethodInfo = typeof(EventSubscriptionInterceptor).GetMethod("DelegateWrapper", BindingFlags.NonPublic | BindingFlags.Static);
      private EventDelegate<EventInfoBase> GenerateDelegate(Delegate d)
      {
         MethodInfo closedMethod = s_eventMethodInfo.MakeGenericMethod(d.Method.GetParameters()[0].ParameterType);
         var newDel = closedMethod.Invoke(null, new object[] { d }) as EventDelegate<EventInfoBase>;
         return newDel;
      }
