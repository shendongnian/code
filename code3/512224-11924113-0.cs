    protected ObservableCollection<Operator> _operators;
    public ObservableCollection<Operator> Operators {
        get { return _operators; }
        set {
            _operators = value;
            _onPropertyChanged("Operators");
        }
    }
    private QuestionOption _selectedItem;
        public QuestionOption SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    if (SelectedIndex == -1)
                        SelectedIndex = Operators.IndexOf(value);
                    _selectedItem = value;
                    _onPropertyChanged("SelectedItem");
                }
            }
        }
        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    _onPropertyChanged("SelectedIndex");
                }
            }
        }
