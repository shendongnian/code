    public class IssuerRecord
    {
        private bool isFrozen = false;
        
        private string propA;
        public string PropA
        { 
            get { return propA; }
            set
            {
                if( isFrozen ) throw new NotSupportedOperationException();
                propA = value;
            }
        }
    
        public void Freeze() { isFrozen = true; }
    }
