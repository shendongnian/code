    public void SendData(object payloadData)
        {
            if (payloadData == null) return;
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, _queueName);
            var brokeredMessage = new BrokeredMessage(payloadData);
            brokeredMessage.Properties["messageType"] = payloadData.GetType().AssemblyQualifiedName;
            queueClient.Send(brokeredMessage);
        }
