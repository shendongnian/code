    [HttpGet]
    public ActionResult Search()
    {
        return PartialView("_SearchFormPartial");
    }
    
    [HttpPost]
    public ActionResult Search(string query)
    {
        if(query != null)
        {
            try
            {
                var searchlist = rep.Search(query);
    
                var model = new ItemViewModel()
                {
                    NewsList = new List<NewsViewModel>()
                };
                return PartialView("_SearchResultsPartial", model);
            }
            catch (Exception e)
            {
                // handle exception
            }
        }
        return PartialView("Error");
    }
