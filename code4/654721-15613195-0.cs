    // Decorate with test fixture attribute so NUnit knows it's a test
    [TestFixture]
    class MainViewModelTests
    {           
        // The interfaces/instances you will need to test with - this is your test subject
        MainViewModel _mainVM;
        // You can mock the other interfaces:
        Mock<IWindowManager> _windowManager;
        Mock<IEventAggregator> _eventAggregator; 
        // Setup method will run at the start of each test
        [SetUp]
        public void Setup() 
        {
            // Mock the window manager
            _windowManager = new Mock<IWindowManager>();               
            // Mock the event aggregator
            _windowManager = new Mock<IEventAggregator>(); 
 
            // Create the main VM injecting the mocked interfaces
            // Mocking interfaces is always good as there is a lot of freedom
            // Use mock.Object to get hold of the object, the mock is just a proxy that decorates the original object
            _mainVM = new MainViewModel(_windowManager.Object, _eventAggregator.Object);
        }
        // Create a test to make sure the VM subscribes to the aggregator (a GOOD test, I forget to do this a LOT and this test gives me a slap in the face)
        [Test]
        public void Test_SubscribedToEventAggregator()
        {
            // Test to make sure subscribe was called on the event aggregator at least once
            _eventAggregator.Verify(x => x.Subscribe(_mainVM));
        }
        // Check that window state toggles ok when it's called
        [Test]
        public void Test_WindowStateTogglesCorrectly()
        {
            // Run the aggregator test at the start of each test (this will run as a 'child' test)
            Test_SubscribedToEventAggregator();
            // Check the default state of the window is Normal
            Assert.True(_mainVM.WindowState == WindowState.Normal);
        
            // Toggle it
            _mainVM.ToggleWindowState();
   
            // Check it's maximised
            Assert.True(_mainVM.WindowState == WindowState.Maximised);
           
            // Check toggle again for normal
            _mainVM.ToggleWindowState();
        
            Assert.True(_mainVM.WindowState == WindowState.Normal);
        }
        // Test the title changes correctly when the method is called
        [Test]
        public void Test_WindowTitleChanges()
        {
             Test_SubscribedToEventAggregator();
             _mainVM.ChangeTitle("test title");
             Assert.True(_mainVM.Title == "test title");
        }
    }
