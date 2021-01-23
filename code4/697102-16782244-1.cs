    var messages = await Task.Factory.FromAsync<IEnumerable<BrokeredMessage>>(Client.BeginReceiveBatch(3, null, null), Client.EndReceiveBatch);
    
    messages.AsParallel().WithDegreeOfParallelism(3).ForAll(item =>
    {
    	ProcessMessage(item);
    });
