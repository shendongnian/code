    public ItemExtended : Item
    {
    	public List<Location> AssociatedLocations { get; set; }
    	public List<Location> AvailableLocations { get; set; }
    }
    
    ItemExtended GetItemExtendedById(long idItem);
