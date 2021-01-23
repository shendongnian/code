    private static string GetFontNameFromFile(string filename)
    {
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        fontCollection.AddFontFile("path_to_font");
        return fontCollection.Families[0].Name;
    }
