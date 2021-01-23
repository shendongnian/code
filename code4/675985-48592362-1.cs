    [Binding]
    public class IWinIfIAmBatmanFeature
    {
        private bool iAmBatman;
        [StepArgumentTransformation(@"(am ?.*)")]
        public bool AmToBool(string value)
        {
            return value == "am";
        }
        [Given(@"I (.*) the Batman")]
        public void WhoAmI(bool amIBatman)
        {
            iAmBatman = amIBatman;
        }
        [StepArgumentTransformation(@"(defeat|am defeated by)")]
        public bool WinLoseToBool(string value)
        {
            return value == "defeat";
        }
        [Then(@"I (.*) the Joker")]
        public void SuccessCondition(bool value)
        {
            Assert.AreEqual(iAmBatman, value);
        }
    }
