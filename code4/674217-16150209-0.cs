    public class SettingsModel : ViewModelBase
    {
        private bool _value;
        public bool Value
        {
            get { return _value; }
            set { Set(() => Value, ref _value, value); }
        }
        private string _kind;
        public string Kind
        {
            get { return _kind; }
            set { Set(() => Kind, ref _kind, value); }
        }
    }
