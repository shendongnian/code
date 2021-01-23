    public Supplier Add(Supplier supplier)
    {
        try
        {
            _ctx.AddToSupplier(supplier);
            _ctx.SaveChanges();
             return supplier;
        }
        catch (Exception ex)
        {
            _ctx.Supplier.Detach(supplier);
            throw;
        }
    }
