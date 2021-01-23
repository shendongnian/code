        public int? AccountId { get; set; }
        //workaround for entity framework lazy loading problem
        Account account;
        public virtual Account Account
        {
            get
            {
                return account;
            }
            set
            {
                account = value;
                
                
                if (value == null)
                {
                    AccountId = null;
                }
                    
            }
        }
