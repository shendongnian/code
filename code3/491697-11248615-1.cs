        Expression<Func<AccountModel, bool>> accountModelQuery = a => a.Bal == 0;
        Expression<Func<Account, bool>> accountQuery = a => accountModelQuery.Compile()(new AccountModel()
        {
            Id = a.Id,
            Bal = a.Balance,
            Name = a.CustomerName
        });
        var account = new Account()
        {
            Balance = 7,
            Id = 2,
            CustomerName = "Bob"
        };
        Console.WriteLine(accountQuery.Compile()(account));
        Console.ReadLine();
