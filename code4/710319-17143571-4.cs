    public class MyWCFService : IMyWCFService
    {
        private PayoutService service = new PayoutService();
        public PayoutResult Payout(string username, PayoutModel model)
        {
            return this.service(username, model);
        }
    }
