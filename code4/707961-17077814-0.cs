    Dim mcls As New [MyClass]
    Dim a As Assembly = Assembly.LoadWithPartialName("ClassLibrary1")
    Dim t As Type = a.GetType("ClassLibrary1.MyClass")
    Dim x = t.InvokeMember("add", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, mcls, New Object() {1, 2})
    Dim y = t.InvokeMember("Add", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod, Nothing, mcls, New Object() {2, 3})
