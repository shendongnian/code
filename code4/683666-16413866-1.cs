    Events events;
    public SDKCommunicatie(Envents eventsInstance)
    {
        events = eventsInstance;
    }
    public void onLogon(string username, string directory, string system)
    {
      events.LogInState = false;
    }
