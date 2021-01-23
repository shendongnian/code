    private String _myField;
        public String MyProperty
        {
            get
            { return _myField; }
            set
            { SetAndNotify(ref _myField, value, () => MyProperty); }
        }
