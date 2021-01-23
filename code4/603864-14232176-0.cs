    public void MethodSample1(Itest variable)
    {
        variable.TestString = "some sample data";
        string localTestString = variable.TestString;
        Console.WriteLine(variable.TestString);
        MethodSample2(variable);
        variable.TestString = localTestString;
        Console.WriteLine(variable.TestString);
    }
