    public string Error
    {
        set { _errorLabel.Text = value; }
    }
    private void SetText()
    {
        if(EnglishSelected)
            Error = "English";
    }
