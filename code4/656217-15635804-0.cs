    public class Pump
    {
        public int PumpID { get; set; }
        public string PumpName { get; set; }
        public string LogicalNumber { get; set; }
    
        public override bool Equals(object o)
        {
            var casted = o as Pump;
            if (casted == null)
                return false;
    
            return PumpID == o.PumpID;
        }
    
        public override int GetHashCode()
        {
            return PumpID.GetHashCode();
        }
    }
