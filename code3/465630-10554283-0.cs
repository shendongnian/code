    public static List<IComparable<Base>> BigList = new List<IComparable<Base>>();
    static void Main(string[] args)
    {
        Class1 c1 = new Class1();
        Class2 c2 = new Class2();
        Class3 c3 = new Class3();
        BigList.Add(c1);
        BigList.Add(c2);
        // This will now cause a compile error
        // BigList.Add(c3);
        Check(new Class1());
    }
    public static void Check(Base bb)
    {
        foreach (IComparable<Base> c in BigList)
        {
            if (c.CompareTo(bb) < 0)
                Console.WriteLine("Less Than");
            else if (c.CompareTo(bb) == 0)
                Console.WriteLine("Equal");
            else if (c.CompareTo(bb) > 0)
                Console.WriteLine("Greater Than");
        }
    }
