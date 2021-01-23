    private NameValueCollection GenerateNameValueCollection(HttpCookie cookie, int productId, int quantity)
    {
        var collection = new NameValueCollection();
        foreach (var value in cookie.Values)
        {
            //If the current element isn't the first empty element.
            if (value != null)
            {
                collection.Add(value.ToString(), cookie.Values[value.ToString()]);
            }
        }
    
        //Does this product exist in the cookie?
        if (cookie.Values[productId.ToString()] != null)
        {
            collection.Remove(productId.ToString());
            //Get current count of item in cart.
            int tmpAmount = Convert.ToInt32(cookie.Values[productId.ToString()]);
            int total = tmpAmount + quantity;
            collection.Add(productId.ToString(), total.ToString());
        }
        else //It doesn't exist, so add it.
        {
            collection.Add(productId.ToString(), quantity.ToString());
        }
    
        if (!collection.HasKeys())
            collection.Add(productId.ToString(), quantity.ToString());
                
        return collection;
    }
