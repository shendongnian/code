        public class Account
        {
            public Account(bool isEmptyItem =false)
            {
                this.EmptyItem = isEmptyItem;
            }
    
            public Int32 Id { get; set; }
            public string Number { get; set; }
            public string Description1 { get; set; }
            public string Description2 { get; set; }
            public string Language { get; set; }
    
            public bool EmptyItem { get; private set; } 
        }
       IList<Account> _account = new List<Account>();
       _account.Add(new Account(true))
       _account.AddRange(Account_repository.GetAll());
      
