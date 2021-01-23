    public string DisplayName
    {
        get { return string.format("{0}, {1}", LastName, FirstName); }
    }
    CB_Coehn.DisplayMemberPath = "DisplayName";
