    public virtual IList<StoreOrderItem> NonVoucherOrderItems
    {
        get
        {
            return this.StoreOrderItems.Where(x => !x.IsVoucher()).ToList();
        }
    }
