    public void SomeTestMethod()
    {
        var before = System.GC.GetTotalMemory(false);
        // call your method
        var used = before - System.GC.GetTotalMemory(false);
        var unreclaimed = before - System.GC.GetTotalMemory(true);
    }
