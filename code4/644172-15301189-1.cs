    public class Facility
    {
        public string ID { get; set; }
        public string Fac_Name { get; set; }
        // Follow the guidelines to override GetHashCode(), etc. as well.
        // This is just a rough example.
        public override bool Equals(Object obj)
        {
            var fac = obj as Facility;
            if (fac == null) return false;
            
            if (Object.ReferenceEquals(this, fac)) return true;
            return (this.ID == fac.ID) && (this.Fac_Name == fac.Fac_Name);
        }
    }
