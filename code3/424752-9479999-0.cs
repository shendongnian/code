    public string TextProperty
    {
        get
        {
            return _textProperty;
        }
        set
        {
            if (_textProperty != value)
            {
                _doubleProperty = this.TransformAndValidateString(value);               
                 _textProperty = value;
            }
        }
    }
