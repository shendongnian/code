    public abstract class A
    {
        protected abstract double Field { get; }
    
        public double SquaredField { get { return Field * Field; } }
    }
