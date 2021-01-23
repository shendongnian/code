    // Not affected by JSon deserialization
    [ScriptIgnore]
    public Coordinate Coordinate {get; set;}
    
    // Serialized/Deserialized by JSon
    public double[] Location { 
        get 
            {
                return new double[] {Coordinate.Latitude,Coordinate.Longitude};
            } 
        set
            {
                Coordinate = new Coordinate(value[0],value[1]);
            }
    }
