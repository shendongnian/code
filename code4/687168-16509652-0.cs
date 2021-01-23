    using (soforumEntities ctx = new soforumEntities())
    {
          Article a = ctx.Articles.Where(c => (c.ArticleStatus != null && c.ArticleStatus.HasValue && c.ArticleStatus.Value != true)).OrderBy(x => x.ArticleStatus).Skip(1).Take(1).SingleOrDefault();
                Console.WriteLine(a.Id + a.Name);
    }
