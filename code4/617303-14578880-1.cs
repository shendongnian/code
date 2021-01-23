    [TestMethod]
    public void UnhandledTest()
    {
        using (var okEvent = new ManualResetEventSlim())
        using (var notOkEvent = new ManualResetEventSlim())
        {
            UnhandledExceptionEventHandler handler = (o, e) =>
                {
                    if (e.ExceptionObject is ApplicationException)
                        okEvent.Set();
                    else notOkEvent.Set();
                };
            AppDomain.CurrentDomain.UnhandledException += handler;
            var thread = new Thread(() => { throw new ApplicationException(); });
            thread.Start();
            var result = EventWaitHandle.WaitAny(new[] { notOkEvent.WaitHandle, okEvent.WaitHandle }, 10000);
            Assert.AreEqual(1, result);
            AppDomain.CurrentDomain.UnhandledException -= handler;
        }
    }
