    public class Descendent : Base
    {
        public Descendent()
        {
            DetermineDefaultMyPropertyValue();
        }
    
        private string _myProperty;
        public string MyProperty {
            get { return _myProperty; }
            set { _myProperty = value; }
        }
    
        private void DetermineDefaultMyPropertyValue()
        {
            _myProperty = "Default value"; 
        }
        protected override void OnPropertyChanged(string propertyName)
        {
            // some property changed logic
        }
    }
