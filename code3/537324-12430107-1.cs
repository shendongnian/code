      public static T Invoke<T>(uint addr, CallingConvention conv) where T : class
            {
              var type = typeof(T);
                if (!cache.Contains(type))
                    cache.Set<T>(type, NativeHelper.GetDelegateForFunctionPointer<T>(addr, conv));
    
                return cache.Get<T>(type);
            }
