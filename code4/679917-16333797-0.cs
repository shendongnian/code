    public LocationModel
    {
    	...
    }
    
    public CreateItemViewModel : ItemModel
    {
    	public List<LocationModel> AssociatedLocations { get; set; }
    	public List<LocationModel> AvailableLocations { get; set; }
    	...
    }
