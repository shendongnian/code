    private static string[] pboardTypes = new string[] { "NSStringPboardType" };
    public static void SetText(string text)
    {
        NSPasteboard.GeneralPasteboard.DeclareTypes(pboardTypes, null);
        NSPasteboard.GeneralPasteboard.SetStringForType(text, pboardTypes[0]);
    }
    public static string GetText()
    {
        return NSPasteboard.GeneralPasteboard.GetStringForType(pboardTypes[0]);
    }
