    internal class Customer
    {
        private int _id; 
        private bool _isRegistered;
        private bool _isPremium;
        private bool _canOrderProducts;
        public Customer(IEnumerable<IEvent> eventHistory)
        {
            foreach (var evt in eventHistory)
                ApplyEvent(evt);
        }
        public IEnumerable<IEvent> Register(int id, RegisterNewCustomerCommand cmd, CompanyIntelligenceReport report)
        {
            if (report.IsBankrupt)
                yield return new CustomerRegistrationWasRefused(cmd.RegistrationId, "Customer's company is bankrupt");
            var isPremium = IsPremiumCompany(report);
            yield return ApplyEvent(new NewCustomerWasRegistered(cmd.RegistrationId, id, isPremium, cmd.FirstName, cmd.LastName, cmd.Email, cmd.WorksForCompanyID));
        }
        public IEnumerable<IEvent> ChangeEmail(string newEmailAddress)
        {
            EnsureIsRegistered("change email");
            yield return ApplyEvent(new CustomerEmailWasChanged(_id, newEmailAddress));
        }
        public IEnumerable<IEvent> ChangeCompany(int newCompanyId, CompanyIntelligenceReport report)
        {
            EnsureIsRegistered("change company");
            var isPremiumCompany = IsPremiumCompany(report);
            if (!_isPremium && isPremiumCompany)
                yield return ApplyEvent(new CustomerWasAwardedPremiumStatus(_id));
            else 
            {
                if (_isPremium && !isPremiumCompany)
                    yield return ApplyEvent(new CustomerPremiumStatusRevoked(_id, "Customer changed workplace to a non-premium company"));
                if (report.IsBankrupt)
                    yield return ApplyEvent(new CustomerLostBuyingCapability(_id, "Customer changed workplace to a bankrupt company"));
            }
        }
        // ... handlers for other commands
        private bool IsPremiumCompany(CompanyIntelligenceReport report)
        {
            return !report.IsBankrupt && 
                (report.AccumulatedSales > 1000000 || report.LastQuarterSales > 10000);
        }
        private void EnsureIsRegistered(string forAction)
        {
            if (_isRegistered)
                throw new DomainException(string.Format("Cannot {0} for an unregistered customer", forAction));
        }
        private IEvent ApplyEvent(IEvent evt)
        {
            // build up only the status needed to take domain/business decisions.
            // instead of if/then/else, event hander wiring could be used.
            if (evt is NewCustomerWasRegistered)
            {
                _isPremium = evt.IsPremiumCustomer;
                _isRegistered = true;
                _canOrderProducts = true;
            }
            else if (evt is CustomerRegistrationWasRefused)
                _isRegistered = false;
            else if (evt is CustomerWasAwardedPremiumStatus)
                _isPremium = true;
            else if (evt is CustomerPremiumStatusRevoked)
                _isPremium = false;
            else if (evt is CustomerLostBuyingCapability)
                _canOrderProducts = false;
            return evt;
        }
    }
