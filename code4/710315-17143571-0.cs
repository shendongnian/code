    public enum PayoutResult
    {
        UserNotFound,
        Success,
        FundsUnavailable,
        DBError
    }
    public class UserProfile
    {
        public float Balance { get; set; }
        public string Username { get; set; }
        // other properties and domain logic you may have
        public bool Withdraw(PayoutModel model)
        {
            if (this.Balance >= model.Amount)
            {
                this.Balance -= model.Amount;
                model.Balance = this.Balance;
                return true;
            }
            return false;
        }
    }
    public class PayoutService
    {
        IUserRepository userRepository;
        public PayoutService()
        {
            this.userRepository = new UserRepository();
        }
        public PayoutResult Payout(string userName, PayoutModel model)
        {
            var user = this.userRepository.GetAll().SingleOrDefault(u => u.Username == userName);
            if (user == null)
            {
                return PayoutResult.UserNotFound;
            }
            if (user.Withdraw(model))
            {
                return this.userRepository.SaveUser(user) ? PayoutResult.Success : PayoutResult.DBError;
            }
            return PayoutResult.FundsUnavailable;
        }
    }
