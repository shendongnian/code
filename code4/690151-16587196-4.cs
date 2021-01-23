    class FooExplicit : IFoo
    {
        // IFoo f = new FooExplicit(); <- Bar is visible
        // FooExplicit fe = new FooExplicit(); <- there is no Bar
        string IFoo.Bar { get; private set; }
    }
