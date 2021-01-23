    [Test]
    public void ProducedMessage_IsCorrect()
    {
        AreEqual(BusinessLibrary.ProduceMessage(), System.Environment.MachineName);
    }
