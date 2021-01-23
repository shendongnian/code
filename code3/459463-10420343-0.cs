    WebChannelFactory<ICalculator> factory = new WebChannelFactory<ICalculator>(new Uri(baseAddress));
    ICalculator proxy = factory.CreateChannel();
    using (new OperationContextScope((IContextChannel)proxy))
    {
        WebOperationContext.Current.OutgoingRequest.Headers.Add("referer", "http://stackoverflow.com");
        WebOperationContext.Current.OutgoingRequest.Headers.Add("user-agent", "Mozilla/5.0");
        Console.WriteLine("Add: {0}", proxy.Add(33, 55));
        Console.WriteLine();
    }
    using (new OperationContextScope((IContextChannel)proxy))
    {
        WebOperationContext.Current.OutgoingRequest.Headers.Add("referer", "http://stackoverflow.com");
        WebOperationContext.Current.OutgoingRequest.Headers.Add("user-agent", "Mozilla/5.0");
        Console.WriteLine("Subtract: {0}", proxy.Subtract(44, 33));
        Console.WriteLine();
    }
