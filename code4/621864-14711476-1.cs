    static void Main(string[] args)
    {
        Console.WriteLine(BaseClass.GetPropertyByDataMemberName("p1").Name);   // should work
        Console.WriteLine(BaseClass.GetPropertyByDataMemberName("p2").Name);   // should not work
        Console.WriteLine(BaseClass.GetPropertyByDataMemberName<SubClassOne>("p1").Name); // should work
        Console.WriteLine(BaseClass.GetPropertyByDataMemberName<SubClassOne>("p2").Name); // should work
    }
