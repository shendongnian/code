    using FooA = A.Foo;
    namespace N1
    {
        // knows about FooA;
        using FooB = B.Foo;
    }
    namespace N2
    {
        // knows about FooA
        // does not know about FooB
    }
