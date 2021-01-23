    var fixture = new Fixture();
    // retrieve internal FolderEvent(EventType, DateTime) ctor
    // using FolderEvent class as NotificationEvent is abstract
    var notificationEventCtor = typeof(FolderEvent).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        new Type[] { typeof(EventType), typeof(DateTime) },
        null
    );
    // generate 10 random events with some help of LINQ and AutoFixture
    var trashData = Enumerable
        .Range(1, 10)
        .Select(i => new object[]
            {
                fixture.CreateAnonymous<EventType>(),
                fixture.CreateAnonymous<DateTime>() 
            })
        .Select(p => notificationEventCtor.Invoke(p))
        .Cast<NotificationEvent>()
        .ToList();
