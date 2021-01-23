    using (IConnection connection = factory.CreateConnection())
    {
        using (IModel channel = connection.CreateModel())
        {
            if (!String.IsNullOrEmpty(EXCHANGE_NAME))
                channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, durable);
    
            if (!String.IsNullOrEmpty(QUEUE_NAME))
                channel.QueueDeclare(QUEUE_NAME, false, false, false, null);
    
            string data = "";
            EventingBasicConsumer consumer = new EventingBasicConsumer();
            consumer.Received += (o, e) =>
            {
                //This is the received message
                data = data + Encoding.ASCII.GetString(e.Body) + Environment.NewLine;
                string processed_data = "processed data = " + data; 
                //I want to write some code here to post the processed message to a different queue.
                //or other idea is "can I use duplex services? 
                using (IModel channel = connection.CreateModel())
                {
                    channel.Publish( ... );
                }
    
            };
            string consumerTag = channel.BasicConsume(QUEUE_NAME, true, consumer);
    
            channel.QueueBind(QUEUE_NAME, EXCHANGE_NAME, ROUTING_KEY, null);
            channel.QueueUnbind(QUEUE_NAME, EXCHANGE_NAME, ROUTING_KEY, null);
            // don't dispose of your channel until you've finished consuming
        }
        // don't dispose of your connection until you've finished consuming
    }
