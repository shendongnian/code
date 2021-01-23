    private Expression<Func<DbObject, MyObject>> GetObjectWithLanguage(string currentLanguage)
    {
        if (currentLanguage == "de")
        {
            return e => new MyObject
            {
                Id = e.ScrId,
                Title = e.Labels.language.German
            }
        }
        else if (currentLanguage == "fr")
        {
            return e => new MyObject
            {
                Id = e.ScrId,
                Title = e.Labels.language.French
            }
        }
        ...
    }
    var results = context.Objects.Where(e => e.Id == myId).Select(GetObjectsWithLanguage("de"));
