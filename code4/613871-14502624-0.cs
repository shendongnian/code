    [XmlIgnore]
    public System.Nullable<int> ContractID { get; set; }
    [XmlAttribute("ContractID")]
    public int ContractIDxml {
    get { return ContractID ?? 00; }
    set { ContractID = value; }
    }
