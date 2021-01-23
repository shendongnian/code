    // This isn't valid code...
    public void Foo<T>() where T : ICodeGenerator
    {
        string type = T.GetDbConnectionType();
    }
