    public abstract class Calculator
    {
        public Calculator() { }
    
        public virtual int Calculate()
        {
            return 0;
        }
    }
    
    public class Operator : Calculator
    {
        public int value { get; set; }
    
        public Operator() { }
    
        public Operator(string name)
        {
        }
    
        public override int Calculate()
        {
            return value;
        }
    }
    
    public class Add : Calculator
    {
        [XmlArray("Operators")]
        [XmlArrayItem("Add", typeof(Add))]
        [XmlArrayItem("Minus", typeof(Minus))]
        [XmlArrayItem("Multiple", typeof(Multiple))]
        [XmlArrayItem("Operator", typeof(Operator))]
        public List<Calculator> calculators { get; set; }
    
        public Add() { }
    
        public Add(List<Calculator> calculators)
        {
            this.calculators = calculators;
        }
    
        public override int Calculate()
        {         
            List<int> value = new List<int>();
    
            foreach (Calculator calculator in calculators)
            {
                value.Add(calculator.Calculate());
            }
    
            return value.Sum();
        }
    }
    
    public class Minus : Calculator
    {
        [XmlArray("Operators")]
        [XmlArrayItem("Add", typeof(Add))]
        [XmlArrayItem("Minus", typeof(Minus))]
        [XmlArrayItem("Multiple", typeof(Multiple))]
        [XmlArrayItem("Operator", typeof(Operator))]
        public List<Calculator> calculators { get; set; }
    
        public Minus() { }
    
        public Minus(List<Calculator> calculators)
        {
            this.calculators = calculators;
        }
    
        public override int Calculate()
        {
            int value = calculators[0].Calculate();
    
            for (int i = 1; i < calculators.Count; i++)
            {
                value -= calculators[i].Calculate();
            }
    
            return value;
        }
    }
    
    public class Divide : Calculator
    {
        [XmlArray("Operators")]
        [XmlArrayItem("Add", typeof(Add))]
        [XmlArrayItem("Minus", typeof(Minus))]
        [XmlArrayItem("Multiple", typeof(Multiple))]
        [XmlArrayItem("Operator", typeof(Operator))]
        public List<Calculator> calculators { get; set; }
    
        public Divide() { }
    
        public Divide(List<Calculator> calculators)
        {
            this.calculators = calculators;
        }
    
        public override int Calculate()
        {
            int value = calculators[0].Calculate();
    
            for (int i = 1; i < calculators.Count; i++)
            {
                value /= calculators[i].Calculate();
            }
    
            return value;
        }
    }
    
    public class Multiple : Calculator
    {
        [XmlArray("Operators")]
        [XmlArrayItem("Add", typeof(Add))]
        [XmlArrayItem("Minus", typeof(Minus))]
        [XmlArrayItem("Multiple", typeof(Multiple))]
        [XmlArrayItem("Operator", typeof(Operator))]
        public List<Calculator> calculators { get; set; }
    
        public Multiple() { }
    
        public Multiple(List<Calculator> calculators)
        {
            this.calculators = calculators;
        }
    
        public override int Calculate()
        {
            int value = calculators[0].Calculate();
    
            for (int i = 1; i < calculators.Count; i++)
            {
                value *= calculators[i].Calculate();
            }
    
            return value;
        }
    }
    
    public class xPlugin
    {
        [XmlElement("Add", typeof(Add))]
        [XmlElement("Minus", typeof(Minus))]
        [XmlElement("Multiple", typeof(Multiple))]
        [XmlElement("Operator", typeof(Operator))]
        public Calculator calculator { get; set; }
    }
    
    public class xPlugins
    {
        [XmlElement("xPlugin", typeof(xPlugin))]
        public xPlugin[] Plugin { get; set; }
    }
