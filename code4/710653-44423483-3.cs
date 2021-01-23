    public class UnicornViewModel
    {
        [Required]
        public string Name { get; set; }
    
        public SuperPower PrimarySuperPower { get; set; }
    
        public SuperPower SecondarySuperPower { get; set; }
        [Required]
        public string PrimarySuperPowerName 
        {
            get { return PrimarySuperPower.Name; }
            set { PrimarySuperPower.Name = value; }
        }
        public string SecondarySuperPowerName 
        {
            get { return SecondarySuperPower.Name; }
            set { SecondarySuperPower.Name = value; }
        }
    }
