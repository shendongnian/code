        public LoadTestUserContext UserContext
        {
            get
            {
                return TestContext.Properties["$LoadTestUserContext"] as LoadTestUserContext;
            }
        }
