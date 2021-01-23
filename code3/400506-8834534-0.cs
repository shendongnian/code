    public Color FromString(string name)
    {
        if(String.IsNullOrWhitespace(name))
        {
            throw new ArgumentException("name");
        }
        KnownColor knownColor;
        if(Enum.TryParse(name, out knownColor))
        {
            return Color.FromKnownColor(knownColor);
        }
        return ColorTranslator.FromHtml(name);
    }
