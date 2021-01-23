    interface I { void Foo(); }
    struct S : I { public void Foo() {} }
    
    S s = new S();
    s.Foo(); // No boxing.
    
    I i = s; // Box occurs when casting to interface.
    i.Foo();
