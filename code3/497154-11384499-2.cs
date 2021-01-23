    void DoSomething(FooBarMode mode)
    {
        switch (mode) // just as an example
        {
            case FooBarMode.FrontToBack:
                Console.WriteLine("FrontToBack");
                break;
            case FooBarMode.BackToFront:
                Console.WriteLine("BackToFront");
                break;
            case FooBarMode.Whatever:
                Console.WriteLine("Whatever");
                break;
            default:
                throw new ArgumentOutOfRangeException("mode");
        }
    }
