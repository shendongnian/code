    public string this[string columnName]
    {
        get 
        {
            string result = null;
            if (string.IsNullOrEmpty(this.GetType().GetProperty(columnName).GetValue(this) as string))
            {
                result = "Mandatory field required";
            }
            return result;
        }
    }
