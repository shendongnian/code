    public class Parameters
    {
        public readonly bool ContainsSquareBrackets;
    
        public Parameters(string paras)
        {
            if(ContainsSquareBrackets = paras.Contains(']') || paras.Contains('['))
            {
                 // do something ...
            }
        }
    }
