    public static void SendAPersonByValue(ref Person p)
    {
        p.age = 99;
        p = new Person("TOM", 999);
    }
