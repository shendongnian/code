    public List<Language> GetLanguageList(LanguageMapper ctx, int? languageId)
    {
        var query = ctx.LANGUAGELIST.AsQueryable();
        if (languageId.HasValue)
        {
            query = query.Where(x => x.LanguageId == languageId.Value);
        }
    
        List<Language> languages = query.Select(e => new Language()
                                        {
                                            LanguageId = e.LANGUAGEID,
                                            LanguageName = e.LANGUAGE
                                        })
                                        .ToList();                    
        return languages;
    }
