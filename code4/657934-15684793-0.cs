    public static ShoppingCart GetCart(HttpContextBase context)
    {
        var cart = new ShoppingCart();
        cart.ShoppingCartId = cart.GetCartId(context);
        return cart;
    }
