    // Validates a postcode and returning a list of errors. If the list is empty, the postcode is valid.
    public List<string> ValidatePostcode(string postcode)
    {
        List<string> errors = new List<string>();
        // Assuming postcode is not null. Otherwise, create another check.
        if (postcode.Length > 3)
            errors.Add("Postcode exceeded maximum length of 5");
        if (postcode.Contains("a"))
            errors.Add("Postcode cannot contain the letter a");
        return errors;
    }
