    public object ClassFactory(string ClassName)
    {
        switch(ClassName)
        {
            case "A": return new A();
            case "B": return new B();
        }
    }
