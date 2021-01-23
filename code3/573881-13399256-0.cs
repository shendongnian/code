    do
            {
                ...
                NewAccount.Balance = int.Parse(FileToRead.ReadLine());
                NewAccount.Address = new Account.AddressClass();
                NewAccount.Address.Country = FileToRead.ReadLine();
                ...
            } while ((line = FileToRead.ReadLine()) != null);
