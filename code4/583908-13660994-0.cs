        public void Withdraw(decimal amount) // The Problem is in this method**
        {
            if (this.Balance < MinBalance)
            {
                throw new ApplicationException("Insufficient funds");
            }
            else
            {
                this._Balance -= amount;
            }
        }
