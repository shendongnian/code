	public class Region
    {
      public virtual int RegionID { get; set;}
      public virtual IList<Store> Stores { get; set; }
    }
	
	public class Store
    {
	    public virtual int StoreId { get; set;}
	    public virtual Region Region { get; set; }
    }
