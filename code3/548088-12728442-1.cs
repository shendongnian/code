    var firstItem = PossibleValues.Cast<object>().FirstOrDefault(o => o != null);
    var type = string.Empty;
    if (firstItem != null)
    {
        type = firstItem.GetType().ToString();
    }
