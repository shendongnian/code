    public class BaseClass 
    {
        IDependent _dependent;
        public BaseClass(IDependent dependent)
        {
             _dependent = dependent;
        }
        public void Alpha() {
            _depdendent.Beta();
        }
        public void Gamma() {
            _depdendent.Delta();
        }
    }
