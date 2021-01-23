    public MyClass(Component parent)
    {
        parent.Disposed += (s,e) => this.Dispose();
    }
    
