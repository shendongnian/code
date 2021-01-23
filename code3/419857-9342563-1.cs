    void M()
    {
        int b = 1;
        try
        { 
            N(out b);
        }
        catch (FooException)
        {
            Console.WriteLine(b);
        }
    }
    void N(out int c)
    {
        c = 123;
        P();
        c = 456;
    }
    void P()
    {
        throw new FooException();
    }
