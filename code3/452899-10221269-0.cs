    public abstract GroceryCart : IGroceryCart
    {
        public void Checkout(IEnumerable<IGroceryItem> itemsToBuy)
        {
            foreach (var item in itemsToBuy)
            {
                item.EnsureFreshness();
            }
            this.InternalCheckout(itemsToBuy);
        }
        protected abstract void InternalCheckout(IEnumerable<IGroceryItem> itemsToBuy);
    }
