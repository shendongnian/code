        private decimal  price;
        [XmlElement(DataType="decimal")]
        public string  Price
        {
            get { return price.ToString("c"); }
            set { price = Convert.ToDecimal(value); }
        }
 
