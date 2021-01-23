    [HttpPost]
    public ActionResult Action(SearchModel search)
    {
       
        return RedirectToRoute("Action",new
        {
             controller = "Controller",
             action = "Action",
             color = search.Color,
             price = search.Price,
             brand = search.Brand,
             model = search.Model
        });
    
    }
