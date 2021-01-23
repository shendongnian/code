    static Dictionary<string, List<MappingFields>> MappingCollections;
    
    public void TicketTrack(Tickets[] tickets)
    {
        if (MappingCollections == null) MappingCollections = loadCodes(Location, fileName);
    
        ...
    } 
