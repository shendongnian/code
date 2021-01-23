    [XmlType("transaction")]
    public sealed class Transaction
    {
        [XmlElement("transactionDate")]
        public DateTime TransactionDate { get; set; }
        
        [XmlIgnore]
        public decimal Amount { get; set; }
        
        [XmlElement("transactionAmount")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string AmountSerialized
        {
            get
            {
                return Amount.ToString(CultureInfo.CreateSpecificCulture("sv-SE"));
            }
            set
            {
                decimal amount;
                Decimal.TryParse(value, NumberStyles.Any, CultureInfo.CreateSpecificCulture("sv-SE"), out amount);
                Amount = amount;
            }
        }
    
        [XmlElement("transactionDescription")]
        public string Description { get; set; }
    
        [XmlElement("transactionType")]
        public int Type { get; set; }
    
        public static Transaction FromXmlString(string xmlString)
        {
            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(typeof(Transaction));
            var instance = (Transaction) serializer.Deserialize(reader);
    
            return instance;
        }
    }
