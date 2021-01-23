    public string SortLanguages(string langs)
    {
        List<string> languages = langs.Split(';').Select(s => s.Trim()).ToList();
        
        languages.Sort();
        PlaceAtFirstPositionIfExists(languages, "anglais");
        PlaceAtFirstPositionIfExists(languages, "francais");
        return string.Join(" ; ", languages);
    }
    private void PlaceAtFirstPositionIfExists(IList<string> languages, string language)
    {
        if (languages.Contains(language))
        {
                languages.Remove(language);
                languages.Insert(0, language);
        }
    }
