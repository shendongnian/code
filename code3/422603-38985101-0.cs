    [TestMethod]
    public void ScheduleItsIneligibilityJob_HasValid_CronSchedule()
    {
        // Arrange
        var factory = new StdSchedulerFactory();
        IScheduler scheduler = factory.GetScheduler();
        
        // Assert
        AssertEx.NoExceptionThrown<FormatException>(() =>
            // Act
            _service.ScheduleJob(scheduler)
        );
    }
    public sealed class AssertEx
    {
        public static void NoExceptionThrown<T>(Action a) where T:Exception
        {
            try
            {
                a();
            }
            catch (T)
            {
                Assert.Fail("Expected no {0} to be thrown", typeof(T).Name);
            }
        }
    }
