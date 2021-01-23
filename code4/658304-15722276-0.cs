    NamespaceManager namespaceManager = NamespaceManager.Create();
    
    TokenProvider nameSpaceManagerTokenProvider = TokenProvider.CreateWindowsTokenProvider(
    	new List<Uri>() { namespaceManager.Address }, new NetworkCredential(user, password));
    
    namespaceManager.Settings.TokenProvider = nameSpaceManagerTokenProvider;
    
    if (namespaceManager.QueueExists(QueueName))
    {
    	namespaceManager.DeleteQueue(QueueName);
    }
    
    QueueDescription qd = new QueueDescription(QueueName);
    
    namespaceManager.CreateQueue(qd);
    
    QueueClient myQueueClient = QueueClient.Create(QueueName);
    
    BrokeredMessage sendMessage = new BrokeredMessage("Hello, World!");
    
    myQueueClient.Send(sendMessage);
