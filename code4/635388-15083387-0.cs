    var events = _context.Context.Events;
    foreach(var event in events)
    {
        // Assuming the property is named RSVPs
        event.RSVPs = event.RSVPs.Where(o => o.UserName.Equals(userName));
    }
    return events;
