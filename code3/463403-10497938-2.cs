    IEnumerable<MyItem> result;
    if (condition1)
    {
        result = this.Items.Where(arg => arg.ProductId == "123");
    }
    else if (condition2)
    {
        result = this.Items.Where(arg => arg.ProductPK == "123");
    }
