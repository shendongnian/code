    class savingaccount : account
    {
        public override void withdraw(float amt)
        {
            if (trans >= 10)
            {
                Console.WriteLine("Number of transactions exceed 10.");
                return;
            }
            if (balance - amt < 500)
                Console.WriteLine("Below minimum balance.");
            else
            {
                base.withdraw(amt);
                trans++;
            }
        }
    }
