    [TestMethod]
    public void WeakReferenceTest2()
    {
        var wRef2 = CallInItsOwnScope(() =>
        {
            var obj = new object();
            var wRef = new WeakReference(obj);
            wRef.IsAlive.Should().BeTrue(); //passes
            GC.Collect();
            wRef.IsAlive.Should().BeTrue(); //passes
            return wRef;
        });
        GC.Collect();
        wRef2.IsAlive.Should().BeFalse(); //used to fail, now passes
    }
    private T CallInItsOwnScope<T>(Func<T> getter)
    {
        return getter();
    }
