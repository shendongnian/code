    // Bad design
    public void Foo(out bar, object param) {
    }
    // Good design
    public void Foo(object param, out bar) {
    }
