    public class FacilityEqualityComparer : IEqualityComparer<Facility>
    {
        public bool Equals(Facility fac1, Facility fac2)
        {
            return fac1.ID.Equals(fac2.ID) && fac1.Fac_Name.Equals(fac2.Fac_Name);
        }
        public int GetHashCode(Facility fac)
        {
            string hCode = fac.ID + fac.Fac_Name;
            return hCode.GetHashCode();
        }
    }
