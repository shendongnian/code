    SomeOtherEntity
        List<Source> SourcesList { get; set; }
    Destination
        List<string> ThingsWithNames { get; set; }
    var destination = Mapper.Map<Destination>(someOtherEntity);
    // now destination.ThingsWithNames is a List<string> containing your Source names
