        private static void CalculateDetails(int id)
        {
            // Creating a new DeviceContext is not expensive.
            // No need to create outside of this method.
            using (var dc = new TestDataContext())
            {
                // TODO: adjust IsolationLevel to minimize deadlocks
                using (new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions {IsolationLevel = IsolationLevel.Serializable}))
                {
                    TestItem item = dc.TestItems.Single(i => i.Id == id);
                    // work done here
                    dc.SubmitChanges();
                }
            }
        }
