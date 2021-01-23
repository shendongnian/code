    dynamic dynamicObject = new DerivedFromDynamicObject();
    var callSiteBinder = Binder.InvokeMember(CSharpBinderFlags.None, "Bar", Enumerable.Empty<Type>(), typeof(Program),
    	new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
    var callSite = CallSite<Action<CallSite, object>>.Create(callSiteBinder);
    callSite.Target(callSite, dynamicObject);
