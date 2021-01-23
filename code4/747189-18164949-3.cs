    //** Get Article
    Public ActionResult Article (int ID)
    {
    Article article = db.Find(ID);
    return(article)
    }
    
    //*Add comments
    [HttpPost]
    public ActionResult Addcomment (int articleID, string CommentTxt)
    {
      Article article = db.Find(ID);
      Comment comment = new Comment();
      db.Comments.Add(comment);
      comment.ArticleID = articleID;
      comment.CommentTxt = CommentTxt;
      db.SaveChanges;
    
      return PartialView(article);
    }
    
    
    //**Get List of comments after adding new comment
    public ActionResult AllComments(int articleID)
    {
      Article article = db.Find(ID);
      var comments = db.Comments.Where(a=>a.ArticleID == articleID).ToList();
      return PartialView(comments);
    }
