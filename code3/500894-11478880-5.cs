    public class DomainCheckoutCommandHandler : ICommandHandler<CheckoutCommand>
    {
        private readonly IEntityDataStorage _repos;
        private readonly IEmailSender _email;
        private readonly ILogger _log;
    
        public DomainCheckoutCommandHandler(IEntityDataStorage repos, 
            IEmailSender email, ILogger log)
        {
            _repos = repos;
            _email = email;
            _log = log;
        }
    
        public void Handle(CheckoutCommand command)
        {
            // use _repos to Add an entry to a database table
            // use _email to issue the receipt
            // use _log to log the purchase
        }
    }
