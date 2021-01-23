    private string _textboxtext;
    public string TextBoxText 
    {
        get{return _textboxtext;} 
        set
        {
            _textboxtext=value.Replace("\r",""); 
            OnPropertyChanged();
        }
    }
