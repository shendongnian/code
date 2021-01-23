    public class Core
    {
        public double Parameter1;
        public double Parameter2;
    
        public Core()
        {
            this.Calculations = new List<Core>();
        }
    
        public double Calc1()
        {
            return (Parameter1 * Parameter2);
        }
    
        public List<Core> Calculations { get; private set; }
    }
