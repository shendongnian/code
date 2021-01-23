    IQueryOver<Mod, Event> query = session
      .QueryOver<Mod>()
      .JoinQueryOver<Event>(mod => mod.EventList)
      .WhereRestrictionOn(evnt => evnt.Type.Id).IsIn(new object[] { 1, 2});
    
    var result = query.List<Mod>();
