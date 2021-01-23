    using (var txn = new TransactionScope())
    {
        ctx.Database.ExecuteSqlCommand("truncate table tb_expensesall");
        ctx.Database.ExecuteSqlCommand("truncate table tb_wholesale");
        ctx.Database.ExecuteSqlCommand("truncate table tb_singlesale");
        ctx.Database.ExecuteSqlCommand("truncate table tb_purchase");
        txn.Complete();
    }
    new MessageWindow(this, Resources.GetString("Warn"), Resources.GetString("DeleteSuccess"));
