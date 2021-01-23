    class AddingViewModel : BindableBase {
        private int _valueA;
        public int ValueA {
            get { return _valueA; }
            set { SetProperty(ref _valueA, value, "ValueA", OnValueAChanged); }
        }
        
        private void OnValueAChanged() { UpdateIsTabEnabled(); }
        
        private int _valueB;
        public int ValueB {
            get { return _valueB; }
            set { SetProperty(ref _valueB, value, "ValueB", OnValueBChanged); }
        }
        
        private void OnValueBChanged() { UpdateIsTabEnabled(); }
        
        private bool _isTabeEnabled;
        public bool IsTabEnabled {
            get { return _isTabEnabled; }
            private set { SetProperty(ref _isTabEnabled, value, "IsTabEnabled"); }
        }
        
        private void UpdateIsTabEnabled() {
            IsTabEnabled = _valueA + _valueB == 2;
        }
    }
