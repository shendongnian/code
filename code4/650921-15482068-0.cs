    var queue = new BlockingCollection<PriceBookData>();
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            byte[] zmqBuffer = new byte[102400];
            int messageLength;
            socket.Receive(zmqBuffer);
            byte[] message = new byte[messageLength];
            Buffer.BlockCopy(zmqBuffer, 0, message, 0, messageLength);
            PriceBookData priceBook = PriceBookData.CreateBuilder().MergeFrom(message).Build();
            double Type = priceBook.GetPb(0).QuoteType;
            queue.Add(priceBook);
        }
    }, TaskCreationOptions.LongRunning);
    Task.Factory.StartNew(() =>
    {
        foreach (var item in queue.GetConsumingEnumerable())
        {
            //do stuff with item
        }
    }, TaskCreationOptions.LongRunning);
