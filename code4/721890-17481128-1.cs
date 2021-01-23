    List<Event> listOfEvents = new List<Event>();
    foreach (var eachEvent in eventsFromArgus)
    {
        listOfEvents.Add(new Event(eachEvent.OriginTime.ToString(), eachEvent.ReceiveTime.ToString(), eachEvent.EventCode, eachEvent.DeviceName)
    }
