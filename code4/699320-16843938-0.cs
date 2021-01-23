    public void Handle(TryMakeWebServiceCall message)
    {
        try
        {
            var result = client.MakeWebServiceCall(whatever);
            bus.Reply(new ResponseWithTheResult{ ... });
        }
        catch(Exception e)
        {
            Data.FailedAttempts++;
            if (Data.FailedAttempts < 10)
            {
                bus.Defer(TimeSpan.FromSeconds(1), new TryMakeWebServiceCall());
                return;
            }
            throw new ApplicationException("oh noes, we failed 10 times!", e);
        }
    }
