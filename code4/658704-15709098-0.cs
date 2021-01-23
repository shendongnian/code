    public EventRepository()
        {
            HeronEntities context = new HeronEntities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            events = context.Events.ToList();
        }
