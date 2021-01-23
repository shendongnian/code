    public class Selectable<T>: ViewModelBase //ViewModelBase should Implement NotifyPropertyChanged.
    {
        private T _model;
        public T Model 
        {   get { return _model; }
            set 
            {
                _model = value;
                NotifyPropertyChange("Model");
            }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyPropertyChange("IsSelected");
            }
        }
 
     }
