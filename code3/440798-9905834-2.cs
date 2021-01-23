    public static IDo CreateIDo(string x)
    {
        switch (x)
        {
            case "A": return new A();
            case "B": return new B();
            default:
                return new C();
        }
    }
