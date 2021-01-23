     class MyProxyGenerator : ProxyGenerator
        {
            public object CreateClassProxyWithoutRunningCtor(Type type, ProxyGenerationOptions pgo, SourcererInterceptor sourcererInterceptor)
            {
                var prxType = this.CreateClassProxyType(type, new Type[] { }, pgo);
                var instance = FormatterServices.GetUninitializedObject(prxType);
                SetInterceptors(instance, new IInterceptor[]{sourcererInterceptor});
                return instance;
            }
             
            private void SetInterceptors(object proxy, params IInterceptor[] interceptors)
            {
                var field = proxy.GetType().GetField("__interceptors");
                field.SetValue(proxy, interceptors);
            }
           
        }
