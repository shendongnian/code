    private FontFamily FindFontByCSSNames(string cssNames)
    {
        string[] names = cssNames.Split(',');
        System.Drawing.Text.InstalledFontCollection installedFonts = new System.Drawing.Text.InstalledFontCollection();
        foreach (var name in names)
        {
            
            var matchedFonts = from ff in installedFonts.Families where ff.Name == name.Trim() select ff;
            if (matchedFonts.Count() > 0)
                return matchedFonts.First();
        }
        // No match, return a default
        return new FontFamily("Arial");
    }
