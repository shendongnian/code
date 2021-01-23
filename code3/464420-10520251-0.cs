    foreach (StockItem item in StockList)
    {
        Master master = new Master();
        master.VoucherNo = BillNo;
        master.Voucher = "Sales";
        master.StockName = item.StockName;
        master.Quantity = item.Quantity;
        master.Unit = item.Unit;
        master.Price = item.UnitPrice;
        master.Amount = item.Amount;
        dbContext.AddToMasters(master);
        dbContext.SaveChanges();
    }
