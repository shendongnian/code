    Abc a = new Abc { Name = "a" };
    Type t = a.GetType();
    BindingFlags staticField = BindingFlags.Static | 
                               BindingFlags.Public | 
                               BindingFlags.GetField;
    BindingFlags instanceProperty = BindingFlags.Instance | 
                                    BindingFlags.Public | 
                                    BindingFlags.GetProperty;
    //prints a
    t.InvokeMember("Name", instanceProperty, default(Binder), a, null);
    //prints wtf
    t.InvokeMember("AbcName", staticField, default(Binder), a, null);
    //throws an exception as there is no member FullName in MyClass
    t.InvokeMember("FullName", instanceProperty, default(Binder), a, null);
    Type tt = t.GetType();
    //prints t.FullName, that is YourNamespace.Abc
    tt.InvokeMember("FullName", instanceProperty, default(Binder), t, null);
