    public class Vat
    {
        XElement self;
        public Vat(XElement parent)
        {
            self = parent.Element("Vat");
            if (null == self)
            {
                parent.Add(self = new XElement("Vat"));
                // Initialize values
                Amount = 0; 
                Rate = 0;
            }
        }
    
        public XElement Element { get { return self; } }
    
        public decimal Amount
        {
            get { return (decimal)self.Attribute("Amount"); }
            set
            {
                XAttribute a = self.Attribute("Amount");
                if (null == a)
                    self.Add(new XAttribute("Amount", value));
                else
                    a.Value = value.ToString();
            }
        }
    
        public decimal Rate
        {
            get { return (decimal)self.Attribute("Rate"); }
            set
            {
                XAttribute a = self.Attribute("Rate");
                if (null == a)
                    self.Add(new XAttribute("Rate", value));
                else
                    a.Value = value.ToString();
            }
        }
    }
