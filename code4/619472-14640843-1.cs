    [XmlType(TypeName = "result")]
    public class Result
    {
        [XmlElement(ElementName = "egov_ref_no")]
        public long EgovRefNo { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "err_code")]
        public int ErrorCode { get; set; }
    }
