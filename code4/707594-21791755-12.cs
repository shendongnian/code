    private string NullCoalesce(string input)
    {
        __ContractRuntime.Requires(input != "", null, null);
        string result;
        if (input == null)
        {
            result = "";
        }
        else
        {
            result = input;
        }
        __ContractRuntime.Ensures(result != null, null, null);
        return input;
    }
