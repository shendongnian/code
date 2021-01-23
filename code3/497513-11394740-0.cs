    public void PrintFuncs()
    {
        foreach (var func in funcList)
        {
            Console.WriteLine(func.Method.Name);
            Console.WriteLine(func.Method.DeclaringType.Name);
        }
    }
