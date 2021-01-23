    private string _surname;
    public string Surname
    {
        get { return _surname.NullSafeTrim(); }
        set { _surname = value.NullSafeTrim(); }
    }
