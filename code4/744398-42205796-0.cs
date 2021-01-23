    public class TestClass {
       
       private readonly ITestService _testService;
       
       public TestClass(ISystemEvents systemEvents, ITestService testService) {
          _testService = testService;
          systemEvents.PowerModeChanged += OnPowerModeChanged;
       }
       private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
       {
          if (e.Mode == PowerModes.Resume)
          {
              _testService.DoStuff();
          }
       }
    }
    
