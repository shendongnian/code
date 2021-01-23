    [Test]
    public void AllPublicMethodsInUnityFacade_ShouldBeVirtual()
    {
        var allPublicMethods = typeof(UnityFacade).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        Assert.IsTrue(allPublicMethods.All(method => method.IsVirtual),
                      string.Join(", ", allPublicMethods.Where(method => !method.IsVirtual)
                                                        .Select(method => method.Name)) + " is not virtual");
    }
