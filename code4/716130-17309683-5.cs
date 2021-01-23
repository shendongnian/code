    public void Method_2(object values)
    {
        var dictionary = values.GetType()
                               .GetProperties()
                               .ToDictionary(pi => pi.Name, pi => pi.GetValue(values));
    }
    public void Method_1(string arg1, string arg2)
    {
        Method_2(new { arg1, arg2 });
    }
