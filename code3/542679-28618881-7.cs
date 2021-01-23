        [TestCleanup]
        public void Cleanup()
        {
            typeof(Math).TypeInitializer.Invoke(null, null);
        }
