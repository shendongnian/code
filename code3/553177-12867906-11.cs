    internal class TaskCompletionSourceHolder
    {
        private readonly TaskCompletionSource<object[]> m_tcs;
        internal object Target { get; set; }
        internal EventInfo EventInfo { get; set; }
        internal Delegate Delegate { get; set; }
        internal TaskCompletionSourceHolder(TaskCompletionSource<object[]> tsc)
        {
            m_tcs = tsc;
        }
        private void SetResult(params object[] args)
        {
            // this method will be called from emitted IL
            // so we can set result here, unsubscribe from the event
            // or do whatever we want.
            // object[] args will contain arguments
            // passed to the event handler
            m_tcs.SetResult(args);
            EventInfo.RemoveEventHandler(Target, Delegate);
        }
    }
    public static class ExtensionMethods
    {
        private static Dictionary<Type, DynamicMethod> s_emittedHandlers =
            new Dictionary<Type, DynamicMethod>();
        private static void GetDelegateParameterAndReturnTypes(Type delegateType,
            out List<Type> parameterTypes, out Type returnType)
        {
            if (delegateType.BaseType != typeof(MulticastDelegate))
                throw new ArgumentException("delegateType is not a delegate");
            MethodInfo invoke = delegateType.GetMethod("Invoke");
            if (invoke == null)
                throw new ArgumentException("delegateType is not a delegate.");
            ParameterInfo[] parameters = invoke.GetParameters();
            parameterTypes = new List<Type>(parameters.Length);
            for (int i = 0; i < parameters.Length; i++)
                parameterTypes.Add(parameters[i].ParameterType);
            returnType = invoke.ReturnType;
        }
        public static Task<object[]> FromEvent<T>(this T obj, string eventName)
        {
            var tcs = new TaskCompletionSource<object[]>();
            var tcsh = new TaskCompletionSourceHolder(tcs);
            Type tcshType = tcsh.GetType();
            MethodInfo setResultMethodInfo = tcshType.GetMethod(
                "SetResult", BindingFlags.NonPublic | BindingFlags.Instance);
            EventInfo eventInfo = obj.GetType().GetEvent(eventName);
            Type eventDelegateType = eventInfo.EventHandlerType;
            DynamicMethod handler;
            if (!s_emittedHandlers.TryGetValue(eventDelegateType, out handler))
            {
                Type returnType;
                List<Type> parameterTypes;
                GetDelegateParameterAndReturnTypes(eventDelegateType,
                    out parameterTypes, out returnType);
                if (returnType != typeof(void))
                    throw new NotSupportedException();
                // I'm going to create an instance-like method
                // so, first argument must an instance itself
                // i.e. TaskCompletionSourceHolder<object> *this*
                parameterTypes.Insert(0, tcshType);
                Type[] parameterTypesAr = parameterTypes.ToArray();
                handler = new DynamicMethod("unnamed",
                    returnType, parameterTypesAr, tcshType);
                ILGenerator ilgen = handler.GetILGenerator();
                // declare local variable of type object[]
                LocalBuilder arr = ilgen.DeclareLocal(typeof(object[]));
                // push array's size onto the stack 
                ilgen.Emit(OpCodes.Ldc_I4, parameterTypesAr.Length - 1);
                // create an object array of the given size
                ilgen.Emit(OpCodes.Newarr, typeof(object));
                // and store it in the local variable
                ilgen.Emit(OpCodes.Stloc, arr);
                // iterate thru all arguments except the zero one (i.e. *this*)
                // and store them to the array
                for (int i = 1; i < parameterTypesAr.Length; i++)
                {
                    // push the array onto the stack
                    ilgen.Emit(OpCodes.Ldloc, arr);
                    // push the argument's index onto the stack
                    ilgen.Emit(OpCodes.Ldc_I4, i - 1);
                    // push the argument onto the stack
                    ilgen.Emit(OpCodes.Ldarg, i);
                    // check if it is of a value type
                    // and perform boxing if necessary
                    if (parameterTypesAr[i].IsValueType)
                        ilgen.Emit(OpCodes.Box, parameterTypesAr[i]);
                    // store the value to the argument's array
                    ilgen.Emit(OpCodes.Stelem, typeof(object));
                }
                // load zero-argument (i.e. *this*) onto the stack
                ilgen.Emit(OpCodes.Ldarg_0);
                // load the array onto the stack
                ilgen.Emit(OpCodes.Ldloc, arr);
                // call this.SetResult(arr);
                ilgen.Emit(OpCodes.Call, setResultMethodInfo);
                // and return
                ilgen.Emit(OpCodes.Ret);
                s_emittedHandlers.Add(eventDelegateType, handler);
            }
            Delegate dEmitted = handler.CreateDelegate(eventDelegateType, tcsh);
            tcsh.Target = obj;
            tcsh.EventInfo = eventInfo;
            tcsh.Delegate = dEmitted;
            eventInfo.AddEventHandler(obj, dEmitted);
            return tcs.Task;
        }
    }
