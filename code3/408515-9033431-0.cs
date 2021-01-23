    public virtual void RemoveItem(string variantSku)
    {
        var itemsToRemove = items.Where(x => x.Variant.VariantSku == variantSku).ToArray();
        foreach(var item in itemsToRemove)
        {
           item.Order = null;
           items.Remove(item);
        }
    }
