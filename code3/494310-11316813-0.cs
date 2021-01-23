        private static bool initialized = false;
        [TestFixtureSetUp]
        public static void FixtureSetup()
        {
            if (initialized) Assert.Fail("fixture setup called multiple times");
            initialized = true;
            ...
        }
