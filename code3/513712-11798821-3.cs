    public Table<Document> GetDocuments()
    {
      return _ctx.GetTable<Document>();
    }
    public Table<Language> GetLanguages()
    {
      return _ctx.GetTable<Languages>();
    }
