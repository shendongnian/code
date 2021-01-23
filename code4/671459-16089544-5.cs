    public static IEnumerable<XElement> InnermostErrors(XElement root)
    {
        var resultCode = root.Attribute("ResultCode");
        if (resultCode == null || resultCode.Value != "ERROR")
        {
            yield break;
        }
        var childrenWithError = root.Elements().Where(e => HasError(e));
        if (!childrenWithError.Any())
        {
            yield return root;
        }
        foreach (var inner in childrenWithError.SelectMany(e => InnermostErrors(e)))
        {
            yield return inner;
        }
    }
