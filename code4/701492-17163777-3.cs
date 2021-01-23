        public void TestStarting(object sender, TestStartingEventArgs e)
        {
            // Pass the UserContext into the TestContext before the test started with all its data retrieved so far data.
            // At the first test it will just be empty
            e.TestContextProperties.Add("UserContext", e.UserContext);
        }
        public void TestFinished(object sender, TestFinishedEventArgs e)
        {
            // do something with the data retrieved form the test 
        }
