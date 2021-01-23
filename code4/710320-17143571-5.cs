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
            // don't set the model properties until we're ok on the db
            bool hasWithdrawn = user.Withdraw(model);
            if (hasWithdrawn && this.userRepository.SaveUser(user))
            {
                model.Balance = this.Balance;
                model.Amount = 0;
                return PayoutResult.Success;
            }
            else if (hasWithdrawn)
            {
                return PayoutResult.DBError;
            }
            return PayoutResult.FundsUnavailable;
        }
    }
