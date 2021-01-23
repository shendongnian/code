    public static class SessionStore
    {
        private const string shoppingListKey = "ShoppingList";
        public static List<int> ShoppingList
        {
            get
            {
                return Session[shoppingListKey] ??                      
                   (Session[shoppingListKey] = new List<int>());
            }
        }
    }
