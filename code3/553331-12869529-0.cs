    public interface IDeposit {
        void Deposit(decimal amount);
    }
    public interface IWithdraw {
        void Withdraw(decimal amount);
    }
    public class Customer : IDeposit, IWithdraw {
        public void Deposit(decimal amount) { throw new NotImplementedException(); }
        public void Withdraw(decimal amount) { throw new NotImplementedException(); }
    }
    public class DepositOnlyATM : IDeposit {
        public void Deposit(decimal amount) { throw new NotImplementedException(); }
    }
