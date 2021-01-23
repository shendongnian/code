    public virtual IEnumerable<StoreOrderItem> NonVoucherOrderItems
    {
        get
        {
            return this.StoreOrderItems.Where(x => !x.IsVoucher());
        }
    }
