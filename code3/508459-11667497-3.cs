       public static Object GetAccount(int AccountId)
        {
            LinqSqlDataContext contextLoad = new LinqSqlDataContext();       
            var q = (from p in contextLoad.MyAccounts
                     where p.AccountId == AccountId
                     select p).FirstOrDefault();
        
            return q;
        }
    var Account = GetAccount(int AccountId) as Account;
    LabelFirstName.Text = Account.FirstName;
    LabelLastName.Text = Account.LastName;
