    [Test]
    public void Execute()
    {
        var a = new A();
        var b = new B();
        a.B = b;
        
        b.Data = new List<byte[]>
        {
            Enumerable.Range(0, 1999).Select(v => (byte)v).ToArray(),
            Enumerable.Range(2000, 3999).Select(v => (byte)v).ToArray(),
        };
        var stream = new MemoryStream();
        var model = TypeModel.Create();
        model.AutoCompile = false;
    #if DEBUG // this is only available in debug builds; if set, an exception is
      // thrown if the stream tries to buffer
        model.ForwardsOnly = true;
    #endif
        CheckClone(model, a);
        model.CompileInPlace();
        CheckClone(model, a);
        CheckClone(model.Compile(), a);
    }
    void CheckClone(TypeModel model, A original)
    {
        int sum = original.B.Data.Sum(x => x.Sum(b => (int)b));
        var clone = (A)model.DeepClone(original);
        Assert.IsInstanceOfType(typeof(A), clone);
        Assert.IsInstanceOfType(typeof(B), clone.B);
        Assert.AreEqual(sum, clone.B.Data.Sum(x => x.Sum(b => (int)b)));
    }
