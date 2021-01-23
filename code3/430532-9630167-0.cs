    private readonly Dictionary<string,MyObj> fields =new Dictionary<string,MyObj>();
    public MyClass()
    {
        fields["var1"] = new MyObj("variable 1");
        fields["var2"] = new MyObj("variable 2");
    }
    public void PrintVar(string fieldName)
    {
        Console.WriteLine(fields[fieldName]);
    }
