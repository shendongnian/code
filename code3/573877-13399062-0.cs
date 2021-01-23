        do
        {
            NewAccount.Name = FileToRead.ReadLine();
            NewAccount.Age = int.Parse(FileToRead.ReadLine());
            NewAccount.Balance = int.Parse(FileToRead.ReadLine());
            NewAccount.Address.Country = FileToRead.ReadLine();
            NewAccount.Address.City = FileToRead.ReadLine();
            NewAccount.Address.FirstLine = FileToRead.ReadLine();
            NewAccount.Address.SecondLine = FileToRead.ReadLine();
            NewAccount.Address.PostCode = FileToRead.ReadLine();
            NewAccount.AccountNumber = int.Parse(FileToRead.ReadLine());
            FileToRead.ReadLine(); // here to absorb the empty line between 'records'
            Accounts.Add(NewAccount);
        } while ((line = FileToRead.ReadLine()) != null);
