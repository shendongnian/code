    public sealed class TemplateFunction : IFunction
    {
        private TemplateFunction() { }
        private static TemplateFunction instance = new TemplateFunction();
    
        public static TemplateFunction Instance { get { return instance; } }
    
        public double y(double x)
        {
            return 0;
        }
    
        public double yDerivative(double x)
        {
            return 0;
        }
    }
