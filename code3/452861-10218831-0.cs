    public abstract class Account
    {
      protected double _balance;
      public abstract bool Credit(double amount);
      public abstract bool Debit(double amount);
    }
    public class SavingAccount : Account
    {
      public double MinimumBalance { get; set; }
      public override bool Debit(double amount)
      {
        if (amount < 0)
          return Credit(-amount);
        double temp = _balance;
        temp = temp - amount;
        if (temp < MinimumBalance)
        {
          return false;
        }
        else
        {
          _balance = temp;
          return true;
        }
      }
      public override bool Credit(double amount)
      {
        if (amount < 0)
          return Debit(-amount);
        _balance += amount;
        return true;
      }
    }
