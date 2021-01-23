    public void DoSomethingOnSomethingElse(object thatSomething, Type type)
    {
        var genericMethod = this.GetType().GetMethods()
                            .Single(x => x.IsGeneric && x.Name == "DoSomethingOnSomethingElse");
        var method = genericMethod.MakeGenericMethod(type);
        method.Invoke(this, new object[]{thatSomething});
    }
