    public class NotificationObject : INotifyPropertChanged
    {
        private readonly Dictionary<string, object> Properties = new Dictionary<string, object>();
        public event PropertyChangedEventHandler PropertyChanged;
        protected TType Get<TType>(string propertyName)
        {
            object value;
            return Properties.TryGetValue(propertyName, out value) ? (TType)value : default(TType);
        }
        protected void Set<TType>(TType value, string propertyName, params string[] dependantPropertyNames)
        {
            Properties[propertyName] = value;
            OnPropertyChanged(propertyName);
            if (dependantPropertyNames != null)
            {
                foreach (string dependantPropertyName in dependantPropertyNames)
                {
                    OnPropertyChanged(dependantPropertyName);
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArts(propertyName));
            }
        }
    }
