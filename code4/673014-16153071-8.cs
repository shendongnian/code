    // assemblies are unloaded on disposal
    using (var analyser = new AssemblyAnalyser())
    {
        var path = "my.unit.tests.dll";
        var b = analyser.IsTestAssembly(path);
        Assert.IsTrue(b);
    }
