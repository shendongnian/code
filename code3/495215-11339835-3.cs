    public void Forward<TResponse>(TResponse response)
        where TResponse : Response
    {
        var subscribers = GetSubscribers<TResponse>();
        if (subscribers != null)
        {
            Subscriber<TResponse> subscriber;
            var afResponse = response as AFResponse;
            if (afResponse != null)
            {
                subscriber = subscribers.SingleOrDefault(s => s.ShortAddress == afResponse.ShortAddress);
            }
            else
            {
                subscriber = subscribers.First();
            }
            if (subscriber != null)
            {
                subscriber.Forward(response);
            }
        }
    }
