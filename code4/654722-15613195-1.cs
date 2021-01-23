    public class MainViewModel : IHandle<someEventMessageArgument> // (this is your subscriber interface)
    { 
        // (and this is the corresponding method)
        public void Handle(someEventMessageArgument message) 
        { 
            // do something useful maybe change object state or call some methods
        }
    }
    // Test the method - you don't need to mock any event aggregator behaviour since you have tested that the VM was subscribed to the aggregator. (OK CM might be broken but that's Robs problem :))
    [Test]
    Test_SomeEventDoesWhatYouAreExpecting()
    {
        _mainVM.Handle(someEventMessageArgument);
    
        // Assert that what was supposed to happen happened...
        Assert.True(SomethingHappened);
    }
