    public ActionResult Show(int id)
    {
      var post=new PostViewModel();
      post=yourService.GetQuestionFromID(id);
      post.Answers=yourService.GetAnswersFromQuestionID(id);
      return View(post);  
    }
