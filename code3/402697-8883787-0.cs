    public class Broker : ActiveDefaultEntity
    {
        public virtual string Name { get; set; }
        public virtual ISet<BrokerInstrument> BrokerInstruments { get; set; }
        public Broker() {
            BrokerInstruments = new HashSet<BrokerInstrument>();
        }
    }
    
    public class Instrument : Entity
    {
        public virtual string Name { get;  set; }
        public virtual string Symbol {get;  set;}
        public virtual ISet<BrokerInstrument> BrokerInstruments { get; set; }
        public virtual bool IsActive { get; set; }  
     
        public Instrument() {
            BrokerInstruments = new HashSet<BrokerInstrument>(); 
        }     
    }
