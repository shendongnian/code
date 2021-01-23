    [XmlRoot("Contracts")]
    public class ContractPosting {
        [XmlElement("Contract", typeof(Contract))]
        public List<Contract> Contracts { get; set; }
    }
