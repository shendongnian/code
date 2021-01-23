        private static readonly ICollection<string> PositiveList = new Collection<string> { "Y", "Yes", "T", "True", "1", "OK" };
        
    public static bool ToBoolean(this string input)
    {
                    return input != null && PositiveList.Any(λ => λ.Equals(input, StringComparison.OrdinalIgnoreCase));
    }
