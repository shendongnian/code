    public bool IsValid
    {
        get
        {
            return !string.IsNullOrWhiteSpace(Firstname) && Salary > 0;
        }
    }
    public Dictionary<string, string> IsValid2
    {
        get
        {
            var errors = new Dictionary<string, string>(); //TODO: Instantiate only if errors are found
            if (string.IsNullOrWhiteSpace(Firstname))
            {
                errors.Add("ERR_001", "First name is invalid.");
            }
 
            if (Salary <= 0)
            {
                errors.Add("ERR_002", "Salary should be a positive number.");
            }
            return errors;
        }
    }
