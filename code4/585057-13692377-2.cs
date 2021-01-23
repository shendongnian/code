    public class Appliance
    {
        public string Make { get; set; }
        public string ApplianceType { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Info { get; set; }
    
        public string ShowString
        {
            get { return String.Format("{0} {1}", Make, ApplianceType); }
        }
    }
