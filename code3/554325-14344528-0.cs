    public class DynamicLocalSettings : BindableBase
    {
        public object this[string name]
        {
            get
            {
                if (ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
                    return ApplicationData.Current.LocalSettings.Values[name];
                return null;
            }
            set
            {
                ApplicationData.Current.LocalSettings.Values[name] = value;
                OnPropertyChanged(name);
            }
        }
    }
