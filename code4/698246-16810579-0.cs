    public DataSet()
    {
            Property1 = LoadProperty1();
            Property2 = LoadProperty2();
            Property3 = LoadProperty3();//can only be done when Property1 is known
    }
    private static Dictionary<string, MyClass1> LoadProperty1()
    {
        // load data
    }
