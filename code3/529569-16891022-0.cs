    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TechTalk.SpecFlow;
    /// <summary>
    /// Partial class for TestContext support.
    /// </summary>
    public partial class DistributionFeature
    {
        /// <summary>
        /// Test execution context.
        /// </summary>
        private TestContext testContext;
        /// <summary>
        /// Gets or sets test execution context.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContext;
            }
            set
            {
                this.testContext = value;
                //see https://github.com/techtalk/SpecFlow/issues/96
                this.TestInitialize();
                FeatureContext.Current["TestContext"] = value;
            }
        }
    }
