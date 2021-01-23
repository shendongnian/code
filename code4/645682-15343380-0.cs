    protected string SetCheckboxValue(bool Contacted)
    {
        if (Contacted)
        {
            return "checked=\"checked\"";
        }
        return String.Empty;
    }
