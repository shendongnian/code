    QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
    channel.BasicConsume(queueName, null, consumer);
    while (m_Listen) {
    try {
    RabbitMQ.Client.Events.BasicDeliverEventArgs e =
    (RabbitMQ.Client.Events.BasicDeliverEventArgs)
    consumer.Queue.Dequeue();
    IBasicProperties props = e.BasicProperties;
    byte[] body = e.Body;
    // ... process the message
    channel.BasicAck(e.DeliveryTag, false);
    } catch (OperationInterruptedException ex) {
    // The consumer was removed, either through
    // channel or connection closure, or through the
    // action of IModel.BasicCancel().
    break;
    }
}
