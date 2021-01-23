    [TestFixture]
    public class FooHubFixture
    {
        private IConnectionManager _connectionManager;
        private IHubContext _hubContext;
        private IMockClient _mockClient;
        [SetUp]
        public void SetUp()
        {
            _hubContext = Substitute.For<IHubContext>();
            _connectionManager = Substitute.For<IConnectionManager>();
            _connectionManager.GetHubContext<FooHub>().Returns(_hubContext);
            _mockClient = Substitute.For<IMockClient>();
            SubstituteExtensions.Returns(_hubContext.Clients.All, _mockClient);
        }
        [Test]
        public void PushFooUpdateToHub_CallsUpdateFooOnHubClients()
        {
            var fooDto = new FooDto();
            var hub = new FooHub(_connectionManager);
            hub.PushFooUpdateToHub(fooDto);
            _mockClient.Received().updateFoo(fooDto);
        }
        public interface IMockClient
        {
            void updateFoo(object val);
        }
    }
    public class FooHub : Hub
        {
            private readonly IConnectionManager _connectionManager;
    
            public FooHub(IConnectionManager connectionManager)
            {
                _connectionManager = connectionManager;
            }
    
            public void PushFooUpdateToHub(FooDto fooDto)
            {
                var context = _connectionManager.GetHubContext<FooHub>();
                context.Clients.All.updateFoo(fooDto);
            }
        }
