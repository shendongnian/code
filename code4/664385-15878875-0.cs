    public class Employer
    {
        public int Id { get; set; }
    }
    public class EmployerAddress
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostZipCode { get; set; }
        public int EmployerId { get; set; }
    }
    public class EmployerDetails
    {
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public int EmployerId { get; set; }
    }
    public class MyRepository : IMyRepository
    {
        public IEnumerable<Employer> GetEmployers()
        {
            return new List<Employer>
                {
                    new Employer {Id = 1},
                    new Employer {Id = 2}
                };
        }
        public IEnumerable<EmployerAddress> GetEmployeeAddresses()
        {
            return new List<EmployerAddress>
                {
                    new EmployerAddress
                        {
                            EmployerId = 1,
                            Address = "address1",
                            City = "city1",
                            Region = "region1",
                            Country = "country1",
                            PostZipCode = "post zip1"
                        },
                    new EmployerAddress
                        {
                            EmployerId = 2,
                            Address = "address2",
                            City = "city2",
                            Region = "region2",
                            Country = "country2",
                            PostZipCode = "post zip2"
                        }
                };
        }
        public IEnumerable<EmployerDetails> GetEmployeeDetails()
        {
            return new List<EmployerDetails>
                {
                    new EmployerDetails
                        {
                            EmployerId = 1,
                            Position = "trainee",
                            Gender = "male",
                            Dob = "22-08-1964"
                        },
                    new EmployerDetails
                        {
                            EmployerId = 2,
                            Position = "trainee2",
                            Gender = "male2",
                            Dob = "22-08-1970"
                        }
                };
        }
    }
    public class EmployerChangedEvent
    {
        public EmployerChangedEvent(Employer selectedEmployer)
        {
            Employer = selectedEmployer;
        }
        public Employer Employer { get; set; }
    }
    public class EmployerViewModel
    {
        private readonly IEventAggregator _events;
        private Employer _selectedEmployer;
        // Configure Ninject properly to get those types
        public EmployerViewModel(IEventAggregator events, IMyRepository myRepository)
        {
            _events = events;
            Employers = myRepository.GetEmployers().ToList();
            EmployerAddressViewModel = new EmployerAddressViewModel(_events, myRepository);
            EmployerDetailsViewModel = new EmployerDetailsViewModel(_events, myRepository);
        }
        public List<Employer> Employers { get; set; }
        public EmployerAddressViewModel EmployerAddressViewModel { get; set; }
        public EmployerDetailsViewModel EmployerDetailsViewModel { get; set; }
        public Employer SelectedEmployer
        {
            get { return _selectedEmployer; }
            set
            {
                _selectedEmployer = value;
                // this notifies the dependent view models in a loosley coupled way
                _events.Publish(new EmployerChangedEvent(_selectedEmployer));
            }
        }
    }
    public class EmployerAddressViewModel :
        IHandle<EmployerChangedEvent> // specifies which events shall be caught
    {
        private readonly IMyRepository _myRepository;
        private Employer _selectedEmployer;
        public EmployerAddressViewModel(IEventAggregator events, IMyRepository myRepository)
        {
            _myRepository = myRepository;
            // this subscribes this view model to the passed event aggregator
            // from your main view model (EmployerViewModel)
            events.Subscribe(this);
        }
        public EmployerAddress EmployerAddress { get; set; }
        public void Handle(EmployerChangedEvent message)
        {
            _selectedEmployer = message.Employer;
            EmployerAddress = _myRepository.GetEmployeeAddresses()
                                           .FirstOrDefault(e => e.EmployerId == _selectedEmployer.Id);
        }
    }
    public class EmployerDetailsViewModel :
        IHandle<EmployerChangedEvent> // specifies which events shall be caught
    {
        private readonly IMyRepository _myRepository;
        private Employer _selectedEmployer;
        public EmployerDetailsViewModel(IEventAggregator events, IMyRepository myRepository)
        {
            _myRepository = myRepository;
            // this subscribes this view model to the passed event aggregator
            // from your main view model (EmployerViewModel)
            events.Subscribe(this);
        }
        public EmployerDetails EmployerDetails { get; set; }
        public void Handle(EmployerChangedEvent message)
        {
            _selectedEmployer = message.Employer;
            EmployerDetails = _myRepository.GetEmployeeDetails()
                                           .FirstOrDefault(e => e.EmployerId == _selectedEmployer.Id);
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            // do this with Ninject
            var employerViewModel = new EmployerViewModel(new EventAggregator(), new MyRepository());
            // this selection should actually be user input
            employerViewModel.SelectedEmployer = employerViewModel.Employers.First();
            // select another one
            employerViewModel.SelectedEmployer = employerViewModel.Employers.Last();
        }
    }
