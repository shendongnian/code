    private void Foo(MyClass cl)
    {
        Type genMethodType = typeof(TestGenericMethodClass);
        MethodInfo genMethod = genMethodType.GetMethod("TestGeneric");
        MethodInfo methodConstructed = genMethod.MakeGenericMethod(cl.GetType());
        object[] args = new object[] { cl };
        methodConstructed.Invoke(instanceOfTestGenericMethodClass, args);
    }
