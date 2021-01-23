    public ActionResult Add(int productId)
    {
        if (Session["ShoppingList"] == null)
        {
            List<int> products = new List<int>(); //#1 conditionally creates the variable only if it is null
        }
    
        products.Add(productId);
        Session["ShoppingList"] = products; //#2 makes the session equal to something that may not ever actually exist
        return View("Index");
    }
