    private void RunTestInCustomDomain(string methodName)
    {
        // selecting the dll from the debug directory using relative directories
        var testDll = @"..\..\..\UnitTests\bin\Debug\UnitTests.dll";
        // first verify the dll exists
        Assert.IsTrue(File.Exists(testDll));
        var assemblyName = AssemblyName.GetAssemblyName(testDll).FullName;
        var domain = AppDomain.CreateDomain(methodName, null, new AppDomainSetup()
        {
            // This is important, you need the debug directory as your application base
            ApplicationBase = Path.GetDirectoryName(testDll)
        });
        // create an instance of your test class
        var tests = domain.CreateInstanceAndUnwrap(assemblyName, typeof(UnitTest1).FullName) as UnitTest1;
        var type = tests.GetType();
        var method = type.GetMethod(methodName);
        // invoke the method inside custom AppDomain
        method.Invoke(tests, new object[]{});
        // Unload the Domain
        AppDomain.Unload(domain);
    }
