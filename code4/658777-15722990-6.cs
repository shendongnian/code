    public class ExampleViewModel : Screen, 
        // We can navigate to this using DefaultNavigationArgs...
        IViewModelParams<DefaultNavigationArgs>, 
        // or SomeNavigationArgs, both of which are nested classes...
        IViewModelParams<SomeOtherNavigationArgs>
    {
        public class DefaultNavigationArgs
        {
            public string Value { get; private set; }
            public DefaultNavigationArgs(string value)
            {
                Value = value;
            }
        }
        public class OtherNavigationArgs
        {
            public int Value { get; private set; }
            public DefaultNavigationArgs(int value)
            {
                Value = value;
            }
        }
        public void ProcessParameters(DefaultNavigationArgs modelParams)
        {            
            // Do something with args
            DisplayName = modelParams.Value;
        }
        public void ProcessParameters(OtherNavigationArgs modelParams)
        {            
            // Do something with args. this time they are int!
            DisplayName = modelParams.Value.ToString();
        }
    }
