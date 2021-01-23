    private void Execute(TypeModel model)
    {
        A a = new A();
        B b = new B();
        b.A = a;
        b.Items.Add(1, a);
        Assert.AreSame(a, b.A);
        Assert.AreSame(b.A, b.Items[1]);
        B deserializedB = (B)model.DeepClone(b);
        Assert.AreSame(deserializedB.A, deserializedB.Items[1]);
    }
