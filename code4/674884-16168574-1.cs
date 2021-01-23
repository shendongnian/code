    private string _txtSurname;
    public string TxtSurname
    {
        get
        {
            return string.IsNullOrWhiteSpace(_txtSurname) ? string.Empty : _txtSurname.Trim();
        }
        set
        {
            _txtSurname = value.Trim();
        }
    }
