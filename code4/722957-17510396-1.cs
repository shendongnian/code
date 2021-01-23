    public class Aircraft : ModelBase
    {
            public Guid SerialNumber { get; set; }
            public string Registration { get; set; }
            public byte[] Image { get; set; }
            
            //This is ForeignKey to AircraftType
            public int AircraftTypeId {get;set;}
            //This is ForeignKey to AircraftLivery
            public int AircraftLiveryId {get;set;}
     
            //Instead of Id use AircraftTypeId
            [ForeignKey("AircraftTypeId")]
            public AircraftType Type { get; set; }
            [ForeignKey("AircraftLiveryId")]
            public AircraftLivery Livery { get; set; }
    }
