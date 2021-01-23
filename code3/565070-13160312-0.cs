    public ActionResult DeleteProductFromCart(int ProductImageId)
    {
        List<int> cart = (List<int>)Session["cart"];
        if (cart == null)
        {
            return new JsonResult() { Data = new { Status = "ERROR" } };
        }
        cart.Remove(ProductImageId);
        
        return new JsonResult() { Data = new { Status = "Success" } };
    }
