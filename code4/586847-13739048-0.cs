    private List<IVehicle> vehicles;
    public IEnumerable<IVehicle> Vehicles 
    { 
        get { return vehicles.AsReadOnly(); }
        private set { vehicles = value; }
    }
