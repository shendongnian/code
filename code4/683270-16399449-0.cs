    public static void Sort(this ShoppingCart cart)
    {
    
        cart.Products = (from item in cart.Products
                         orderby item.Title ascending
                         select item).ToList();
    }
