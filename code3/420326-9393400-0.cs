    Action<int> a = i => { throw new ArgumentException(); };
            
    // When the following code is executed, VS2010 debugger
    // will break on the `ArgumentException` above 
    // but ONLY if the target is .NET 4 (3.5 and lower don't break)
    try { a.DynamicInvoke(5); }
    catch (Exception ex)
    { }
    // this doesn't break
    try { a.Invoke(5); }
    catch (Exception ex)
    { }
    // neither does this
    try { a(5); }
    catch (Exception ex)
    { }
