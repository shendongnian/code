    /// <summary>
    /// Details on the destination of the shipment.
    /// </summary>
    [XmlRoot("destination")]
    public class Destination
    {
        List<Recipient> recipient { get; set; }
    }
    /// <summary>
    /// Recipient details.
    /// </summary>
    [XmlRoot("recipient")]
    public class Recipient
    {
        /// <summary>
        /// Client Id of the recipient; only used if selected as the sort criterion.
        /// </summary>
        /// <remarks>Truncated after 30 characters.</remarks>        
        [XmlElement("client-id")]
        public string ClientID { get; set; } 
        /// <summary>
        /// Name of the individual receiving the shipment.
        /// </summary>
        /// <remarks>Truncated after 44 characters.</remarks>
        [XmlElement("contact-name")]
        public string ContactName { get; set; } 
        
        /// <summary>
        /// Name of the company.
        /// </summary>
        /// <remarks>Truncated after 44 characters.</remarks>
        [XmlElement("company")]
        public string Company { get; set; }
  
        ...
