    public void AddListLine(string lineIn)
        {
            productList.Items.Insert(0, new Product { Id = "ALL", IdAndName = "ALL" });
            ((CurrencyManager)productList.BindingContext[productList]).Refresh();
        }
