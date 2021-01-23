    public MyClass(UserControl uc) : base(uc)
    { 
        if (uc as IMyInterface == null) {
            throw new ArgumentException("You must implement IMyInterface", "uc");
        }
        // etc..
    }
