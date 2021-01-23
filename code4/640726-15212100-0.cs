    public void withdraw(decimal amount)
    {
        if (balance > 0)
        {
           balance -= amount;
        }
        else
        {
           Console.WriteLine("You have no money to withdraw! You're broke!");
           // or else you could charge an overdraft fee as long as you're within 
           // a certain tolerance (minimum of -1000 or something like that). 
        }
    }
