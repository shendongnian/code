    public Foo CreateFoo(TableOne one)
    {
        Foo foo = new Foo();
        foo.Column1 = one.Column1;
        foo.Column2 = one.Column2;
        foo.TwoCount = one.TableTwo.Count();
        return foo;
    }
