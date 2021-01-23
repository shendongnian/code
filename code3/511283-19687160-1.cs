    using(TransactionScope trx= new TransactionScope())
    {
        var basicProperties = _channel.CreateBasicProperties();
        basicProperties.DeliveryMode = 2;
        new RabbitMqResourceManager(_channel, trx);
        _channel.BasicPublish(someExchange, someQueueName, basicProperties, someData);
        trx.Complete();
    }
