    public ActionResult DoSomething(string typeName, int? id)
    {
        Type thisType = this.GetType(); // Get your current class type
        var type = Type.GetType(typeName);
        MethodInfo doSomethingElseInfo = thisType.GetMethod("DoSomethingElse");
        MethodInfo concreteDoSomethingElse = doSomethingElseInfo.MakeGenericMethod(type);
        concreteDoSomething.Invoke(this, null);
    }
