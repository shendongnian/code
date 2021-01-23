    abstract class ExternalResource
    {
        private readonly string m_className;
    
        protected ExternalResource(string classname)
        {
            m_className = className;
        }
    
        protected object GetParameterValue(string name)
        {
            string fullName = name + '_' + m_className;
    
            // actually access the resource using fullName
        }
    }
    
    public class SpecificParameters : ExternalResource
    {
         public SpecificParameters(string className)
             : base(className)
         { }
    
         public int Length { get { return (int)GetParameterValue("length"); } }
    
         …
    }
