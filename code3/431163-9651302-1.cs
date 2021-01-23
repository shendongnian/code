        public IEnumerable<Account> Get(Account account)
        {
            var _context = new List<Account>();
            return _context
                .Where(w => w.UserName == account.UserName
                    && w.Password == account.Password
                    && w.Email == account.Email
                )
                .Select(s => new Account {
                    UserName = s.UserName,
                    Password = s.Password,
                    Email = s.Email
                }).ToList();
        }
