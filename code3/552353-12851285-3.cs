    [TestMethod]
    public void TestFactory()
    {
        var config = RegisterEventProcessorsConfig.GetConfig();
        var factory = new EventProcessorFactory(config.EventProcessors.Cast<EventProcessorMapping>());
        var processor = factory.GetProcessor<EnrollmentEventType>();
        Assert.IsInstanceOfType(processor, typeof(EnrollmentEventProcessor));
    }
