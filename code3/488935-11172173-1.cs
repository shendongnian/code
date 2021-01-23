    public void method(Enumeration e)
    {
        if (!(e == Enumeration.A || e == Enumeration.B)) {
            throw new ArgumentOutOfRangeException("e");
        }
        // ...
    }
