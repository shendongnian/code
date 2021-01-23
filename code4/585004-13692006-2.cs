    public static class LastModifiedTimeUserSetter
    {
      public static void Set<TEntity>(TEntity entity)
      {
         var action = (Action<TEntity>) Properties.GetOrAdd(typeof(TEntity), CreateDynamicSetMethodDelegate);
         if(action != null)
            action(entity);
      }
      static Delegate CreateDynamicSetMethodDelegate(Type type)
      {
         return CreateDynamicSetMethod(type).CreateDelegate(GetActionType(type));
      }
      static DynamicMethod CreateDynamicSetMethod(Type typeWithProperty)
      {
         var methodBuilder = new DynamicMethod(
            "Dynamic_" + typeWithProperty.FullName + "_SetLastModifiedUser",
            typeof (void),
            new[] {typeWithProperty});
         EmitSimpleAssignmentMethod(methodBuilder,
                                    GetIdentityHelperUserNameGetMethod(),
                                    GetPropertySetMethod(typeWithProperty));
         return methodBuilder;
      }
      static MethodInfo GetIdentityHelperUserNameGetMethod()
      {
         return typeof(IdentityHelper).GetProperty("UserName").GetGetMethod();
      }
      static MethodInfo GetPropertySetMethod(Type type)
      {
         var prop = type.GetProperty("LastModifiedUser");
         if (prop == null)
            return null;
         return prop.GetSetMethod();
      }
      static void EmitSimpleAssignmentMethod(DynamicMethod methodBuilder, MethodInfo getMethod, MethodInfo setMethod)
      {
         var il = methodBuilder.GetILGenerator();
         il.Emit(OpCodes.Ldarg_0);
         il.EmitCall(OpCodes.Call, getMethod, null);
         il.EmitCall(OpCodes.Call, setMethod, null);
         il.Emit(OpCodes.Ret);
      }
      static Type GetActionType(Type type)
      {
         return typeof (Action<string>).GetGenericTypeDefinition().MakeGenericType(type);
      }
      static readonly ConcurrentDictionary<Type, Delegate> Properties = new ConcurrentDictionary<Type, Delegate>();
    }
