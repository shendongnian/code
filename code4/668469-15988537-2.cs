    using (var context = new FinancialRecordContext())
    {
        var dict = new Dictionary<string, Bank>();
        foreach (var t in data)
        {
            Bank bank;
            if (!dict.TryGetValue(t.BankName, out bank))
            {
                bank = context.FindOrInsertBank(t.BankName);
                dict.Add(t.BankName, bank);
            }
            
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
