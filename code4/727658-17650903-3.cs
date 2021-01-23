    //you do not need human factory in this example
    public class Human
    {  
        private readonly IEventsAggregator _events;
        //see Handle implementation for details
        //public ITransport Transport { get; set; }
        public Human(IEventsAggregator events)
        {
            _events = events;
        }
        public void Travel(GroundTypes type)
        {
            _events.Publish(new TransportRequest(this, type));
            //see Handle implementation for details
            //if (Transport != null) Transport.Travel();
        }
    }
    public class TransportRequest
    {
        public Human Sender { get; set; }
        public GroundTypes Ground { get; set; }
        public TransportRequest(Human sensder, GroundTypes ground)
        {
            Sender = sender;
            Ground = ground;
        }
    }
    public class TravelAgency : IListener<TransportRequest>, IDisposable
    {
        private readonly IEventsAggregator _events;
        private readonly TransportFactory _tFactory;
        public TravelAgency(IEventsAggregator events, TransportFactory tFactory)
        {
            _events = events;
            _events.Subscribe(this);
            _tFactory = tFactory;
        }
        public void Handle(TransportRequest request)
        {
            var transort = _tFactory.ProvideTransport(...);
            //insert the handling logic here
            //there are two ways to handle this message:
            //1) you give human no control over (and no knowledge of) Transport 
            //and simply call transport.Travel(request.Sender); here
            //2) or you add ITransport property to Human class
            //and do only the assignation here 
            //request.Sender.Transport = transport;
            //and then let the human manage Transport object
        }
        public void Dispose()
        {
            _events.Unsubscribe(this);
        }
    }
