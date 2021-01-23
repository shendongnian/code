    MenuDataProviderSub.Received().GetMenuData(Arg.Is<IEnumerable<string>>(a => VerifyPageIds(ExpectedUserPermissions.AuthorisedPageIds, a)));
    private static bool VerifyPageIds(IEnumerable<string> expected, IEnumerable<string> actual)
    {
        var expectedIds = expected.ToList();
        var actualIds = actual.ToList();
        return expectedIds.Count == actualIds.Count && expectedIds.All(actualIds.Contains);
    }
