    private static bool Validate(string isAllowed)
    {
        var defaultTrueConditions = new[] {"true", "false", "yes", "no"};
        if (string.IsNullOrWhiteSpace(isAllowed) ||
            defaultTrueConditions.Contains(isAllowed, StringComparer.OrdinalIgnoreCase))
        {
            DoSomething();
            return true;
        }
        return false;
    }
