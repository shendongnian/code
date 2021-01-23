    public class Locations {
        public virtual string CountryCode;
        public virtual string CountryName;
        public void Set(string propertyName, string value) {
            if (propertyName == "CountryCode") this.CountryCode = value;
            else if (propertyName == "CountryName") this.CountryName = value;
            else throw new ArgumentException("Unrecognized property '" + propertyName + "'");
        }
    }
