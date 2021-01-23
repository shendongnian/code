    public class Facility
    {
        public string ID { get; set; }
        public string Fac_Name { get; set; }
        // This is just a rough example.
        public override bool Equals(Object obj)
        {
            var fac = obj as Facility;
            if (fac == null) return false;
            
            if (Object.ReferenceEquals(this, fac)) return true;
            return (this.ID == fac.ID) && (this.Fac_Name == fac.Fac_Name);
        }
        public override int GetHashCode()
        {
            var hash = 13;
            if (!String.IsNullOrEmpty(this.ID))
                hash ^= ID.GetHashCode();
            if (!String.IsNullOrEmpty(this.Fac_Name))
                hash ^= Fac_Name.GetHashCode();
            
            return hash;
        }
    }
