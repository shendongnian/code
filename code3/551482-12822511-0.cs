    public class TestCaseStuff
    {
        // Static instance of a random number generator.
        private static readonly Random RNG = new Random();
        public double amt { get; set; }
        public TestCaseStuff()
        {
            this.amt = RNG.Next(0, 20);
        }
        [Category("Release")]
        public IEnumerable<TestCaseData> GetTestCases()
        {
            for (int i = 0; i < 500; i++)
            {
                // NOTE: You need to create a new instance here.
                yield return new TestCaseData(new TestCaseStuff());
            }
        }
    }
