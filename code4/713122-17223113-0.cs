    public ActionResult Add(int productId)
    {
        if (Session["ShoppingList"] == null)
        {
            Session["ShoppingList"] = new List<int>();
        }
    
        ((List<int>)Session["ShoppingList"]).Add(productId);
        return View("Index");
    }
