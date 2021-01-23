    public static void Foo(int a, int b, int c, 
        optionalString aa, optionalString, bb, optionalString cc)
    {
        Object1 o1 = null;
        Object1 o2 = null;
        Object1 o3 = null;
        if (a == 1)
        { o1 = Thing.Property1[aa]; }
        if (b == 1)
        { o2 = Thing.Property2[bb]; }
        if (c == 1)
        { o3 = Thing.Property3[cc]; }
    
        Bar(o1, o2, o3);
    }
