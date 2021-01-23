    abstract class ParameterBase
    {
        protected string ParameterName;
        protected bool IsRequired;
        protected int ParameterId;
    
        public abstract void SetProperties(string xml);
        
    }
