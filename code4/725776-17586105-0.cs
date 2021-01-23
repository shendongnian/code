Given your latest update it seems like the issue is loading the type `classA<>` at run-time. To avoid naming conflicts the C# compiler generates a name like SimpleClassName\`N where `N` is the number of generic type parameters, so to get the `classA<>` type through reflection, use the name namespace.classA\`1. After that, you would simply use the [`MakeGenericType`][1] method:
    var classAType = AssemblyContaingClassA.GetType("namespace.classA`1");
    var classBType = AssemblyContaingClassB.GetType("namespace.classB");
    var genericType = classAType.MakeGenericType(classBType);
    object instance = Activator.CreateInstance(genericType);
