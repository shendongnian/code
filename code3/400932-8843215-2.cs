    public class Power
    {
        XElement self;
    
        public Power(XElement power) { self = power; }
    
        public AlternatePowers AlternatePowers
        { get { return new AlternatePowers(self.Element("AlternatePowers")); } }
    }
    
    public class AlternatePowers
    {
        XElement self;
    
        public AlternatePowers(XElement power) { self = power; }
    
        public Power2[] Powers
        { 
            get 
            { 
                return self.Elements("Power").Select(e => new Power2(e)).ToArray();
            }
        }
    }
    
    public class Power2
    {
        XElement self;
    
        public Power2(XElement power) { self = power; }
    }
