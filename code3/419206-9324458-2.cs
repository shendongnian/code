    private static void AddIfNotNull(List<string> elements, string value)
    {
        if (!String.IsNullOrEmpty(value))
            elements.Add(value);
    }
    public override string ToString()
    {
        List<string> elements = new List<string>();
        AddIfNotNull(elements, description);
        elements.Add(String.Concat(month, day, year));
        elements.Add(amount.ToString("C"));
        AddIfNotNull(elements, paymentMethod);
        AddIfNotNull(elements, trip);
        AddIfNotNull(elements, note);
        return String.Join(", ", elements.ToArray());
    }
