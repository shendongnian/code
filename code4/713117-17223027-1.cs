    public ActionResult Add(int productId)
    {
    	List<int> products;
     
        if (Session["ShoppingList"] == null)
        {
            products = new List<int>();
        }
    	else
    	{
    		products = (List<int>) Session["ShoppingList"];
    	}
    
        products.Add(productId);
        Session["ShoppingList"] = products;
        return View("Index");
    }
