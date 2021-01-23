    public class SomeClassUsingRoot
    {
        public string FindInterestingString()
        {
            return root != null
                ? root.FindInterestingString()
                : null;
        }
        private RootSomething root;
    }
    public class RootSomething
    {
        public string FindInterestingString()
        {
            return FirstProperty != null
                ? FirstProperty.FindInterestingString()
                : null;
        }
        public SomethingTopLevel FirstProperty { get; set; }
    }
    public class SomethingTopLevel
    {
        public string FindInterestingString()
        {
            return SecondProperty != null
                ? SecondProperty.InterestingString
                : null;
        }
        public SomethingLowerLevel SecondProperty { get; set; }
    }
    public class SomethingLowerLevel
    {
        public string InterestingString { get; set; }
    }
