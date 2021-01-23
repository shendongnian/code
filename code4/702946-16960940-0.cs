       [XmlIgnore]            
       public decimal Total
            {
                get
                {
                    return this.totalField;
                }
                set
                {
                    this.totalField = value;
                }
            }
    
    
            [XmlElement("Total")]
            public string TotalString
            {
                get
                {
                    return Total.ToString("F2");
                }
                set
                {
                    decimal total = 0;
                    if (Decimal.TryParse(value, out total))
                        Total = total;
                }
            }
