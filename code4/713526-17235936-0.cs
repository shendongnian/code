    [HttpPost]
    public ActionResult AddToCart(AddToCartModel atm)
    {   
        if (OrderData.CartItems.Count > 0)
            atm.Pos = OrderData.CartItems.Max(i => i.Pos) + 1;
        else 
            atm.Pos = 1;
    
        OrderData.CartItems.Add(atm);
    
        return Content("<p>ITEM ADDED TO CART</p>");//will be returned by ajax
    }
