    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ExpandValues: Values
    {
        public override double Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = value;
            }
        }
        public double Value2 { get; set; }
    
        public ExpandValues()
            : base()
        {
    
        }
        public ExpandValues(string name, double value1, double value2)
            : base(name, value1)
        {
            Value2 = value2;
        }
    }
