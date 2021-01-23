    public bool IsNotEmpty(string value, out string errorMessage)
    {
        errorMessage = "";
        if (value.Length == 0)
        {
            errorMessage = "This Field Is Required";
            return true; //instead of false
        }
        return false;
    }
