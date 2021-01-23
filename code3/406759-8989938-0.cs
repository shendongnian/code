    using (var db = new IntDB())
    {
        var subscription = db.Subscription.Include("Article")
              .Where(s => s.SubsciptionId == subscriptionId).FirstOrDefault();
        if (subscription != null)
        {
            var article = subscription.Article;
            db.DeleteObject(subscription);
            db.SaveChanges();
               
            if (!String.IsNullOrEmpty(article.WebUrl) && article.WebUrl.Equals(@"/ExploderLists"))
            {
                var lstAppIntrfc = new ListAppInterface();
                // the articleId is stored in the entity key here, the article object hasn't been instanicated
                // so it's easier to just get it from the EntityKey.                            
                lstAppIntrfc.RemoveEmailFromListByArticleID((int)articleId.Value, subscription.EmailAddress);
            }
        }
    }
