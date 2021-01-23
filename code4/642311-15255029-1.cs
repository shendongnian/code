    public class BoolListItemViewModel: ListItemViewModel
    {
        private bool _value;
        public bool Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged(() => Value);
            }
        }
    }
