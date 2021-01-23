    static void MyMethod()
    {
        using (new Scope(s => Console.WriteLine(s)))
        {
            // boddy
        }
    }
