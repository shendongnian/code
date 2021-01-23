    using System.Reflextion;
    static void Main()
    {
        if (MemberExists(typeof(Supplier), testStr))
            Console.WriteLine(testStr + " exists in Supplier");
        else
            Console.WriteLine(testStr + " does not exists in Supplier");
    }
    
    public bool MemberExists(Type structure, string name)
    {
        foreach(MemberInfo member in structure.GetMembers())
            if (member.Name == name) return true;
        return false;
    }
