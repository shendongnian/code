    public bool handler1(int input)
    {
        if (input % 2 == 0)
        {
            Console.WriteLine("{0}'s smallest factor is 2");
            return true;
        }
        return false;
    }
    public bool handler2(int input)
    {
        if (input % 3 == 0)
        {
            Console.WriteLine("{0}'s smallest factor is 3");
            return true;
        }
        return false;
    }
    etc.
