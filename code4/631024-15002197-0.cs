    public class Foo : IFoo
    {
        private string _field;
    
        public string Property
        {
            get { return _field; }
        }
    
        private void SetField()
        {
            _field = " foo ";
        }
    
        private string Method()
        {
            SetField();
            return _field.Trim();
        }
    }
