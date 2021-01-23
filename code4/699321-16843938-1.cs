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
                bus.Defer(TimeSpan.FromSeconds(1), message);
                return;
            }
            // oh no! we failed 10 times... this is probably where we'd
            // go and do something like this:
            emailService.NotifyAdministrator("Something went wrong!");
        }
    }
