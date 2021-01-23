    public class FacilityEqualityComparer : IEqualityComparer<Facility>
    {
        public bool Equals(Facility x, Facility y)
    	{
    		return (x.ID == y.ID) && (x.Fac_Name == y.Fac_Name);
    	}
    	
    	public int GetHashCode()
    	{
    	    // ...
    	}
    }
    var facReturnList2 = 
            facReturnList.Select(x => 
                new Facility { ID = x.Fac_Name.Substring(0, 6), 
                      Fac_Name = x.Fac_Name.Substring(0, 3) })
                .Distinct(new FacilityEqualityComparer()).ToList();
