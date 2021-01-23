    public Bank FindOrInsertBank(string bankName)
    {
        var bank = Banks.Local.SingleOrDefault(b => b.Name == bankName);
        if (bank == null)
        {
            var bank = Banks.SingleOrDefault(b => b.Name == bankName);
            if (bank == null)
            {
                bank = new Bank { Name = bankName };
                Banks.Add(bank);
            }
        }
        return bank;
    }
