    [KnownType(typeof(your hardware dto concrete type here))]
    public class ComputerDTO
    {
        [DataMember]
        public ComputerTypeDTO Type { get; set; }
        [DataMember]
        public string ComputerName { get; set; }
        [DataMember]
        public MonitorDTO Monitor { get; set; }
        [DataMember]
        public List<IHardwarePartDTO> Hardware { get; set; }
    }
