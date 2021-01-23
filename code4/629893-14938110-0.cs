    public class ComputerDTO
    {
        [DataMember]
        public ComputerTypeDTO Type { get; set; }
        [DataMember]
        public string ComputerName { get; set; }
        [DataMember]
        public MonitorDTO Monitor { get; set; }
        [DataMember]
        [KnownType(typeof(your hardware dto concrete type here))]
        public List<IHardwarePartDTO> Hardware { get; set; }
    }
