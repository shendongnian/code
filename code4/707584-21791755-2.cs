    private string NullCoalesce(string input)
    {
        Contract.Requires(input != "");
        Contract.Ensures(Contract.Result<string>() != null);
        if (input == null)
            return "";
        return input;
    }
