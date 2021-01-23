    [Test]
    public void PutAndGetMessageWithFloatProperty() {
        using (MQQueue queue = _queueManager.AccessQueue(TestQueue, MQC.MQOO_OUTPUT | MQC.MQOO_INPUT_AS_Q_DEF))
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            MQMessage message = new MQMessage();
            message.SetFloatProperty("TEST_SINGLE", 14.879f);
            message.WriteString("some string");
            message.Format = MQC.MQFMT_STRING;
                
            queue.Put(message); // Writes property value as 14.879
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs-CZ");
            MQMessage readMessage = new MQMessage();
            queue.Get(readMessage); // Throws MQException because 14,879 is correct format
     
            queue.Close();
        }
    }
