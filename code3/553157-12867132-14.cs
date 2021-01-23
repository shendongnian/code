    // Empty events (Action style)
    static Task TaskFromEvent(object target, string eventName) {
        return TaskFromEventHelper<object>(target, eventName, new Func<object>(() => null));
    }
    // One-value events (Action<T> style)
    static Task<T> TaskFromEvent<T>(object target, string eventName) {
        return TaskFromEventHelper<T>(target, eventName, new Func<T, T>(t=>t));
    }
    // Two-value events (Action<T1, T2> or EventHandler style)
    static Task<Tuple<T1, T2>> TaskFromEvent<T1, T2>(object target, string eventName) {
        return TaskFromEventHelper<Tuple<T1, T2>>(target, eventName, new Func<T1, T2, Tuple<T1, T2>>(Tuple.Create));
    }
    static Task<T> TaskFromEventHelper<T>(object target, string eventName, Delegate resultSetter) {
        var tcs = new TaskCompletionSource<T>();
        var addMethod = target.GetType().GetEvent(eventName).GetAddMethod();
        var delegateType = addMethod.GetParameters()[0].ParameterType;
        var methodInfo = delegateType.GetMethod("Invoke");
        var parameters = methodInfo.GetParameters()
                                        .Select(a => Expression.Parameter(a.ParameterType))
                                        .ToArray();
        // building method, which argument count and
        // their types are not known at compile time
        var exp = // (%arguments%) => tcs.SetResult(resultSetter.Invoke(%arguments%))
            Expression.Lambda(
                delegateType,
                Expression.Call(
                    Expression.Constant(tcs),
                    tcs.GetType().GetMethod("SetResult"),
                    Expression.Call(
                        Expression.Constant(resultSetter),
                        resultSetter.GetType().GetMethod("Invoke"),
                        parameters)),
                parameters);
        addMethod.Invoke(target, new object[] { exp.Compile() });
        return tcs.Task;
    }
