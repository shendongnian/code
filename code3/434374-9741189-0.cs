    public class Army
    {
        // Fields
        private List<UnitCategory> _unitCategory;
        private string _armyName;
        // Properties
        [XmlArray("unit-category")]
        public List<UnitCategory> UnitCategory
        {
            get { return _unitCategory; }
            set { _unitCategory = value; }
        }
    }
        [XmlAttribute("name")]
        public string ArmyName
        {
            get { return _armyName; }
            set { _armyName = value; }
        }
