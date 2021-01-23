    private EventHandler foodel;
    public event EventHandler foo {
        add { foodel += value; }
        remove { foodel -= value; }
    }
    public event EventHandler bar;
    ...
    foo.Add((s, e) => { });   // CS0079
    bar.Add((s, e) => { });   // No error
