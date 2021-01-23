    class account
    {
        public virtual void withdraw(float amt)
        {
            if (balance - amt < 0)
                Console.WriteLine("No balance in account.");
            else
                balance -= amt;
        }
    }
