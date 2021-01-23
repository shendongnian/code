    [Pure]
    public void IsNotNullOrEmpty(object input)
    {
        if (typeof(string).IsAssignableFrom(typeof(TInput)))
            return !string.IsNullOrEmpty((string)(object)input)
        else
            return typeof(TInput).IsValueType
                || !ReferenceEquals(input, null);
    }
    Contract.Requires<ArgumentException>(IsNotNullOrEmpty(input),
        "Input object must represent an actual value.");
