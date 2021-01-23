    public MyForm()
    {
      using(DbEntities db = new DbEntities())
      {
        Articles firstArticle = db.Articles.FirstOrDefault(u => u.statusArticle == false);
        if( firstArticle != null ) ShowArticle( firstArticle );
      }
    }
