    [Authorize]
    public ActionResult AddToCart(int productId, int quantity)
    {
        //If the cart cookie doesn't exist, create it.
        if (Request.Cookies["cart"] == null)
        {
            Response.Cookies.Add(new HttpCookie("cart"));
        }
    
        //Helper method here.
        var values = GenerateNameValueCollection(Request.Cookies["cart"], productId, quantity);
        Response.Cookies["cart"].Values.Add(values);
    
        return RedirectToAction("Index");
    }
