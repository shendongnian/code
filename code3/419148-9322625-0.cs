    public bool IsNotEmpty(string value, out string errorMessage)
        {
            if (value.Length == 0)
            {
                errorMessage = "This Field Is Required";
                return false;
            }
            return true;
        }
