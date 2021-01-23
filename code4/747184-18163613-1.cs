    public ActionResult Details(int id)
    {
       ArticleViewModel model = new ArticleViewModel();
    
       model.Article = _yourDBRepository.GetArticleById(id);
       model.Comments = _yourDBRepository.LoadCommentsByArticleId(id);
       return View(model);
    }
