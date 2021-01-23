    public class CustomerDomainService : IDomainService
    {
        private readonly Func<int> _customerIdGenerator;
        private readonly Dictionary<Type, Func<ICommand, IEnumerable<IEvent>>> _commandHandlers;
        private readonly Dictionary<int, List<IEvent>> _dataBase;
        private readonly IEventChannel _eventsChannel;
        private readonly ICompanyIntelligenceService _companyIntelligenceService;
        public CustomerDomainService(ICompanyIntelligenceService companyIntelligenceService, IEventChannel eventsChannel)
        {
            // mock database.
            var id = 1;
            _customerIdGenerator = () => id++;
            _dataBase = new Dictionary<int, List<IEvent>>(); 
            // external services and infrastructure.
            _companyIntelligenceService = companyIntelligenceService;
            _eventsChannel = eventsChannel;
            // command handler wiring.
            _commandHandlers = new Dictionary<Type,Func<ICommand,IEnumerable<IEvent>>>();
            SetHandlerFor<RegisterNewCustomerCommand>(cmd => HandleCommandFor(-1,
                (id, cust) => cust.Register(id, cmd, ReportFor(cmd.WorksForCompanyId))));
            SetHandlerFor<ChangeCustomerEmail>(cmd => HandleCommandFor(cmd.CustomerId, 
                (id, cust) => cust.ChangeEmail(cmd.NewEmail)));
            SetHandlerFor<ChangeCustomerCompany>(cmd => HandleCommandFor(cmd.CustomerId,
                (id, cust) => cust.ChangeCompany(cmd.NewCompanyId, ReportFor(cmd.NewCompanyId))));
        }
        public void PerformCommand(ICommand cmd)
        {
            var commandHandler = _commandHandlers[cmd.GetType()]; 
            var resultingEvents = commandHandler(cmd);
            foreach (var evt in resultingEvents)
                _eventsChannel.Publish(evt);
        }
        private IEnumerable<IEvent> HandleCommandFor(int customerId, Func<int, Customer, IEnumerable<IEvent>> handler)
        {
            if (customerId <= 0)
                customerId = _customerIdGenerator();
            var events = handler(LoadCustomer(customerId));
            SaveCustomer(customerId, events);
            return events;
        }
        private void SetHandlerFor<TCommand>(Func<TCommand, IEnumerable<IEvent>> handler)
        {
            _commandHandlers[typeof(TCommand)] = cmd => handler((TCommand)cmd);
        }
        private CompanyIntelligenceReport ReportFor(int companyId)
        {
            return _companyIntelligenceService.GetIntelligenceReport(companyId);
        }
        private Customer LoadCustomer(int customerId)
        { 
            var currentHistoricalEvents = new List<IEvent>();
            _dataBase.TryGetValue(customerId, out currentHistoricalEvents);
            return new Customer(currentHistoricalEvents);
        }
        private void SaveCustomer(int customerId, IEnumerable<IEvent> newEvents)
        {
            List<IEvent> currentEventHistory;
            if (!_dataBase.TryGetValue(customerId, out currentEventHistory))
                _dataBase[customerId] = currentEventHistory = new List<IEvent>();
            currentEventHistory.AddRange(newEvents);
        }
    }
