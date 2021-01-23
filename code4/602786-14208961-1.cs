    namespace Helper
    {
        public class XsltHelper
        {
            private XsltHelper();
            public readonly XsltHelper Instance = new XsltHelper();
    
            public double CalculatePerctange(int a, int b)
            {
                return b == 0 ? 0 : ((double)a * 100) / b;
            }
        }
    }
