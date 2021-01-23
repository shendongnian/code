    var one = new EntityOne();
    LastModifiedTimeUserSetter.Set(one);
    Console.WriteLine(one.LastModifiedUser);
    public static class LastModifiedTimeUserSetter
    {
      public static void Set<TEntity>(TEntity entity)
      {
         var method = Properties.GetOrAdd(typeof (TEntity), GetSetMethod);
         var action = (Action<string>) Delegate.CreateDelegate(typeof (Action<string>), entity, method);
         action(IdentityHelper.UserName);
      }
      static MethodInfo GetSetMethod(Type type)
      {
         var prop = type.GetProperty("LastModifiedUser");
         if (prop == null)
            return null;
         return prop.GetSetMethod();
      }
      static readonly ConcurrentDictionary<Type, MethodInfo> Properties = new ConcurrentDictionary<Type, MethodInfo>();
    }
