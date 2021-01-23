    abstract class AnAbstract
    {
        public virtual string Name { get { return this.GetType().Name; } }
        public virtual string Description { get { return String.Empty; } }
    }
    abstract class ANumericAbstract : AnAbstract
    {
        public virtual double Min = double.MinValue;
    }
    class NumericImpl : ANumericAbstract
    {
        public override string Description { get { return "A numeric implementation"; } } 
        public override double Min { get { return 0; } }
    }
