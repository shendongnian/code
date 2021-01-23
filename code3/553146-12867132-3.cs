    // One-value events (Action<T> style)
    static Task<T> TaskFromEvent<T>(object target, string eventName) {
        var eventInfo = target.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
        var addMethod = eventInfo.GetAddMethod();
        var delegateType = addMethod.GetParameters()[0].ParameterType;
        var tcs = new TaskCompletionSource<T>();
        var resultSetter = (Action<T>)tcs.SetResult;
        var d = Delegate.CreateDelegate(delegateType, resultSetter, "Invoke");
        addMethod.Invoke(target, new object[] { d });
        return tcs.Task;
    }
    // Empty events (Action style)
    static Task TaskFromEvent(object target, string eventName) {
        var eventInfo = target.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
        var addMethod = eventInfo.GetAddMethod();
        var delegateType = addMethod.GetParameters()[0].ParameterType;
        var tcs = new TaskCompletionSource<object>();
        var resultSetter = (Action)(() => tcs.SetResult(null));
        var d = Delegate.CreateDelegate(delegateType, resultSetter, "Invoke");
        addMethod.Invoke(target, new object[] { d });
        return tcs.Task;
    }
    // Two-value events (Action<T1, T2> or EventHandler style)
    static Task<Tuple<T1, T2>> TaskFromEvent<T1, T2>(object target, string eventName) {
        var eventInfo = target.GetType().GetEvent(eventName, BindingFlags.Instance | BindingFlags.Public);
        var addMethod = eventInfo.GetAddMethod();
        var delegateType = addMethod.GetParameters()[0].ParameterType;
        var tcs = new TaskCompletionSource<Tuple<T1, T2>>();
        var resultSetter = (Action<T1, T2>)((t1, t2) => tcs.SetResult(Tuple.Create(t1, t2)));
        var d = Delegate.CreateDelegate(delegateType, resultSetter, "Invoke");
        addMethod.Invoke(target, new object[] { d });
        return tcs.Task;
    }
