    public void DoSomething()
    {
        b.Add(new A()); // (1)
        List<B> tmp = (List<B>)b; // (2)
        foreach (B item in tmp) { // (3)
            // ...
        }
    }
