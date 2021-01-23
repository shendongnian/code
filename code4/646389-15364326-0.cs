    public void AddArticle(Article s)
    {
        ArticleLINQDataContext db = new ArticleLINQDataContext();
        ArticleTable a = 
            new ArticleTable { 
                                 Id = s.Id, // *see question below code sample
                                 Content = s.Content, 
                                 Name = s.Name, 
                                 Subject = s.Subject, 
                                 Created = (DateTime)s.Created 
                             };
        db.ArticleTables.InsertOnSubmit(a);   // <-- note it's "a" instead of "s"
        db.SubmitChanges();
    }
