    public class MyWCFService : IMyWCFService
    {
        private PayoutService service = new PayoutService();
        public PayoutResult Payout(string username, PayoutModel model)
        {
            return this.service.Payout(username, model);
        }
    }
