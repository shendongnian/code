    FilterModel Transfer(Product product)
    {
        var fm = new FilterModel();
        fm.Code = product.Code;
        fm.Children = new List<FilterModel>();
        foreach (var p in product.Children)
        {
            fm.Children.Add(Transfer(p));
        }
        return fm;
    }
