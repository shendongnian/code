    public class FacilityEqualityComparer : IEqualityComparer<Facility>
    {
        public bool Equals(Facility x, Facility y)
    	{
    		return (x.ID == y.ID) && (x.Fac_Name == y.Fac_Name);
    	}
    	
    	public int GetHashCode(Facility fac)
    	{
            var hash = 13;
            if (!String.IsNullOrEmpty(this.ID))
                hash ^= ID.GetHashCode();
            if (!String.IsNullOrEmpty(this.Fac_Name))
                hash ^= Fac_Name.GetHashCode();
            
            return hash;
    	}
    }
    var facReturnList2 = 
            facReturnList.Select(x => 
                new Facility { ID = x.Fac_Name.Substring(0, 6), 
                      Fac_Name = x.Fac_Name.Substring(0, 3) })
                .Distinct(new FacilityEqualityComparer()).ToList();
