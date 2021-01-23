    public ActionResult Add(int productId)
    {
        if (Session["ShoppingList"] == null)
        {           
            Session["ShoppingList"] = new List<int>();
        }
        List<int> products = (List<int>)Session["ShoppingList"]
        products.Add(productId);
        return View("Index");
    
    }
