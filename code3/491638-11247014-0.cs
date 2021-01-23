    public void My_Func(Object input, Type t)
    {
        object test = new object();
        test = Convert.ChangeType(test, t);
        test = TypeDescriptor.GetConverter(t).ConvertFromString(input.ToString());
    }
