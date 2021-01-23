    public class ArmyListing :  IEnumerable<Army>, IEnumerator<Army>
    {
        // Fields
        private List<Army> _army;
        // Properties
        [XmlArray("army-category")]        
        public List<Army> Army
        {
            get { return _army; }
            set { _army = value; }
        }   
        // Public Methods
        public void SerializeToXML(ArmyListing armyListing)
        {
            try
            {
                //armyListing.army.Add(army);
                XmlSerializer serializer = new XmlSerializer(typeof(ArmyListing));
                //XmlSerializer serializer = new XmlSerializer(typeof(ArmyListing), new Type[] { typeof(ArmyListing) });
                TextWriter textWriter = new StreamWriter(@"C:\Temp\40k.xml");
                serializer.Serialize(textWriter, armyListing);
                textWriter.Close();
            }
            catch (Exception ex) { }
        }
        #region IEnumerator/IEnumerable req methods
        [XmlIgnore]
        private int position = -1;
        
        // Added to prevent Exception
        // To be XML serializable, types which inherit from IEnumerable must have an implementation of Add(System.Object)
        //at all levels of their inheritance hierarchy. ThereIsOnlyRules.ArmyListing does not implement Add(System.Object).
        public void Add(Army fix)
        {
            if (_army == null)
                _army = new List<Army>();
            _army.Add(fix);
        }
        #endregion            
    
        public IEnumerator<Army> GetEnumerator()
        {
            return this;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        
        [XmlIgnore]
        public Army Current
        {
            get { return _army[position]; }
            
        }
        public void Dispose()
        {
            
        }
        [XmlIgnore]
        object IEnumerator.Current
        {
            get { return _army[position]; }
        }
        public bool MoveNext()
        {
            position++;
            return (position < Army.Count);
        }
        public void Reset()
        {
            position = 0;
        }
    }
