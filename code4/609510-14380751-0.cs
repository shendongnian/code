    Assembly assembly = Assembly.GetExecutingAssembly();
    Type baseType = typeof(BaseForm);
    foreach (Type type in assembly.GetTypes().Where(t => (t.FullName.Contains("Form") && (t != baseType))))
    {
        if (type.IsSubclassOf(typeof(BaseForm)))
            Console.WriteLine("{0} is subclass of {1}", type, baseType);
    }
