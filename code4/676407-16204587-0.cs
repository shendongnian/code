    [TestMethod]
    public void FlagsTest()
    {
        MemoryProtection mp = MemoryProtection.ReadOnly | MemoryProtection.ReadWrite | MemoryProtection.ExecuteRead | MemoryProtection.ExecuteReadWrite;
        MemoryProtection value = MemoryProtection.Readable | MemoryProtection.Writable;
        Assert.IsTrue((value & mp) == mp);
    }
