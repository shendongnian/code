    class Message
    {
        [XmlIgnore] // set by MessageCollection
        public Model Model { get{return signals==null ? null : signals.Model;} set{signals=new SignalCollection(value);} }
    
        SignalCollection signals;
        public SignalCollection Signals
        {
            get { return signals; }
        }
    }
