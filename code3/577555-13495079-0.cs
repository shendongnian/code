    public class TStockFilterAttributes
    {
        public String Name { get; set; }
        public String Value { get; set; }
    
        public override bool Equals(object obj)
        {
            TStockFilterAttributes other = obj as TStockFilterAttributes;
            if (obj == null)
                return false;
    
            return Name == obj.Name && Value == obj.Value;
        }
    
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Value.GetHashCode();
        }
    }
