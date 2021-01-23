        [TestMethod]
        public void MyTest()
        {
          Helper.RunInWpfSyncContext( async () =>
          {
            Assert.IsNotNull( SynchronizationContext.Current );
            await MyTestAsync();
            DoSomethingOnTheSameThread();
          });
        }
