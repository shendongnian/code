    // Nested Private class
    class DataHolder
    {
        public String AvailabilityRequestFile { get; set; }
        public String PvdnpProducedFile { get; set; }
    }
    
    static Dictionary<String, Action<String, DataHolder>> DataUpdateActions = new Dictionary<String, Action<String, DataHolder>>
    {
        { "AvailabilityRequest", (s,d) => d.AvailabilityRequestFile = s; }
        { "Produced", (s,d) => d.PvdnpProducedFile = s; }
    };
