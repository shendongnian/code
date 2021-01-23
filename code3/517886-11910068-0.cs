    abstract public class ITTechnician
    {
        public bool IsJonSkeet { get; protected set; }
        protected ITTechnician()
        {
            this.IsJonSkeet = false;
        }
    }
    public class JonSkeet : ITTechnician
    {
        public JonSkeet()
        {
            this.IsJonSkeet = true;
        }
    }
    public class Whisperity : ITTechnician
    {
    }
