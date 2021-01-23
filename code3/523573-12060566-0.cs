    private IEnumerable<Vehicle> vehiclesSorted;
    public void FilterByModel(string _model)
    { 
        vehiclesSorted = vehiclesSorted.Where(v => v.Model == _model);
    }
    public void FilterByBrand(string _brand)
    {
        vehiclesSorted = vehiclesSorted.Where(v => v.Brand == _brand);
    }
    public void Mph(int _mph)
    {
        vehiclesSorted = vehiclesSorted.Where(v => v.Mph <= _mph);
    }
    
    public List<Vehicle> Vehicles {
        get {
            return vehiclesSorted.ToList();
        }
    }
