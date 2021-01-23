    internal class TaskCompletionSourceHolder<T>
    {
        private readonly TaskCompletionSource<T> m_tcs;
        private readonly T m_result;
        internal object Target { get; set; }
        internal EventInfo EventInfo { get; set; }
        internal Delegate Delegate { get; set; }
        internal TaskCompletionSourceHolder(TaskCompletionSource<T> tsc, T result)
        {
            m_tcs = tsc;
            m_result = result;
        }
        private void SetResult()
        {
            // this method will be called from emited IL
            // we can set result here or do whatever we want
            m_tcs.SetResult(m_result);
            EventInfo.RemoveEventHandler(Target, Delegate);
        }
    }
    internal static class ExtensionMethods
    {
        private static void GetDelegateParameterAndReturnTypes(Type d,
            out List<Type> parameterTypes, out Type returnType)
        {
            if (d.BaseType != typeof(MulticastDelegate))
                throw new ApplicationException("Not a delegate.");
            MethodInfo invoke = d.GetMethod("Invoke");
            if (invoke == null)
                throw new ApplicationException("Not a delegate.");
            ParameterInfo[] parameters = invoke.GetParameters();
            parameterTypes = new List<Type>(parameters.Length);
            for (int i = 0; i < parameters.Length; i++)
                parameterTypes.Add(parameters[i].ParameterType);
            returnType = invoke.ReturnType;
        }
        internal static Task FromEvent<T>(this T obj, string eventName)
        {
            var tcs = new TaskCompletionSource<object>();
            var tcsh = new TaskCompletionSourceHolder<object>(tcs, null);
            Type tcshType = tcsh.GetType();
            MethodInfo setResultMethodInfo = tcshType.GetMethod(
                "SetResult", BindingFlags.NonPublic | BindingFlags.Instance);
            EventInfo eventInfo = obj.GetType().GetEvent(eventName);
            Type eventDelegateType = eventInfo.EventHandlerType;
            Type returnType;
            List<Type> parameterTypes;
            GetDelegateParameterAndReturnTypes(eventDelegateType,
                out parameterTypes, out returnType);
            if (returnType != typeof(void))
                throw new NotSupportedException();
            // I'm going to create an instance-like method
            // so, first parameter should be of instance type.
            // I.e. TaskCompletionSourceHolder<object> this
            parameterTypes.Insert(0, tcshType);
            DynamicMethod handler = new DynamicMethod("unnamed",
                returnType, parameterTypes.ToArray(), tcshType);
            ILGenerator ilgen = handler.GetILGenerator();
            // load zero-argument (i.e. *this*) onto the evalution stack
            ilgen.Emit(OpCodes.Ldarg_0);
            // call this.SetResult();
            ilgen.EmitCall(OpCodes.Call, setResultMethodInfo, null);
            // and return
            ilgen.Emit(OpCodes.Ret);
            Delegate dEmitted = handler.CreateDelegate(eventDelegateType, tcsh);
            tcsh.Target = obj;
            tcsh.EventInfo = eventInfo;
            tcsh.Delegate = dEmitted;
            eventInfo.AddEventHandler(obj, dEmitted);
            return tcs.Task;
        }
    }
