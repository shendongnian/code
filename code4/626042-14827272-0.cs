    string text = GetDateString(); // Name converted to follow .NET conventions
    if (string.IsNullOrEmpty(text))
    {
        text = "9:00AM"; // Or whatever
    }
    DateTime parsed;
    if (!DateTime.TryParse(text, out parsed))
    {
        parsed = // some default here
    }
