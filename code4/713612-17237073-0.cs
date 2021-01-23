    public static getSpecificProductToShoppingList_Result
                       BuildItemToShoppingList(Nullable<int> productId)
    {
        getSpecificProductToShoppingList_Result product = 
        db.
           getSpecificProductToShoppingList(productId).
           ToList<getSpecificProductToShoppingList_Result>().FirstOrDefault();
        return product;
    }
