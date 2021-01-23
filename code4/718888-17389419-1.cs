    public unsafe bool AreRefsEqual(ref int a, ref int b)
    {
        fixed (int* aptr = &a)
        fixed (int* bptr = &b)
        {
            return aptr == bptr;
        }         
    }
    [TestMethod]
    public void ShouldRefsEqualWork()
    {
        int a = 1, b = 1;
        Assert.IsTrue(AreRefsEqual(ref a, ref a));
        Assert.IsFalse(AreRefsEqual(ref a, ref b));           
    }
