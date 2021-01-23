    public class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class Descendent : Base
    {
        public Descendent()
        {
            DetermineDefaultMyPropertyValue();
        }
        
        public string MyProperty { get; set; }
    
        private void DetermineDefaultMyPropertyValue()
        {
            MyProperty = "Default value"; 
        }
        protected override void OnPropertyChanged(string propertyName)
        {
            // some property changed logic
        }
    }
    
