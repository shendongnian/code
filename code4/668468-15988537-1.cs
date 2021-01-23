    using (var context = new FinancialRecordContext())
    {
        foreach (var t in data)
        {
            Bank bank = context.ChangeTracker.Entries()
                .Where(e => e.Entity is Bank && e.State != EntityState.Deleted)
                .Select(e => e.Entity as Bank)
                .SingleOrDefault(b => b.Name == t.BankName);
            if (bank == null)
                bank = context.FindOrInsertBank(t.BankName);
            
            var tran = new Transaction
            {
                Description = t.Description,
                Value = t.Value,
                TransDate = t.TransDate,
                Bank = bank
            };
            context.Transactions.Add(tran);
        }
        context.SaveChanges();
    }
