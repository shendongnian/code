    public static T GetDelegateForFunctionPointer<T>(uint ptr, CallingConvention conv)
            where T : class
            {
               
                var delegateType = typeof(T);
                var method = delegateType.GetMethod("Invoke");
                var returnType = method.ReturnType;
                var paramTypes =
                    method
                    .GetParameters()
                    .Select((x) => x.ParameterType)
                    .ToArray();
                var invoke = new DynamicMethod("Invoke", returnType, paramTypes, typeof(Delegate));
                var il = invoke.GetILGenerator();
                for (int i = 0; i < paramTypes.Length; i++)
                    il.Emit(OpCodes.Ldarg, i);
                    il.Emit(OpCodes.Ldc_I4, ptr);
                
                il.EmitCalli(OpCodes.Calli, conv, returnType, paramTypes);
                il.Emit(OpCodes.Ret);
                return invoke.CreateDelegate(delegateType) as T;
            }
