    [Serializable]
    public class Angle 
    {
        [XmlAttribute]
        public UnitType Unit;
        [XmlTextAttribute]
        public double Value
        {
            get { return Unit == UnitType.Degree ? Degree : Radian; }
            set
            {
                if (Unit == UnitType.Degree)
                {
                    Degree = value;
                    return;
                }
                Radian = value;
            }
        }
        [XmlIgnore]
        public double Radian { get; set; }
        [XmlIgnore]
        public double Degree { get; set; }
    }
