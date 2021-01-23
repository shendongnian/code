        [WebMethod]
        public static void add_items(string itemslist, Action<string> instanceMethod)
        {
            //get_price(itemslist);// Error An object reference is required for non-static
            instanceMethod(itemlist);
        }
        protected void get_price(string item_id)
        {
        }
