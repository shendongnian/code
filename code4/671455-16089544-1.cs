    public static bool HasError(XElement element)
    {
        var resultCode = element.Attribute("ResultCode");
        return resultCode != null && resultCode.Value == "ERROR";
    }
    var errors = doc.Descendants()
                    .Where(e => HasError(e) && !e.Elements().Any(c => HasError(c)));
