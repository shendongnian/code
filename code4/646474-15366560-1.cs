    public ActionResult Newsfeed()
    {
     List<Article> articleList=new List<Article>();
      
     articleLsit=GetListOfItemsFromSomewhere();
     //now get only 10. you may apply sorting if needed
     articleList=articleList.Take(10); 
    
     return View(articleList);
    }
