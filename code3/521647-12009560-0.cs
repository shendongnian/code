    using FileHelpers;
    
    // ...
    
    [DelimitedRecord(",")]
    class DispatchCall {
        // Just make sure these are in order
        public int AccountID { get; set; }
        public string WorkOrder { get; set; }
        public string Description { get; set; }
        // ...
    }
    // And then to call the code
    var engine = new FileHelperEngine(typeof(DispatchCall));
    engine.Options.IgnoreFirstLines = 1; // If you have a header row
    DispatchCall[] data = engine.ReadFile(FileName) as DispatchCall[];
